using Application.Repository;

namespace Authorization.Middlewares; 

public class TransactionMiddleware(RequestDelegate next) {
    public async Task Invoke(HttpContext context) {
        if (IsTransactionRequired(context)) {
            using var scope = context.RequestServices.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            await unitOfWork.BeginTransactionAsync();
            try {
                await next(context);
                // if the request succeeded, commit the transaction
                await unitOfWork.CommitTransactionAsync();
            }
            catch (Exception) {
                // if an exception occured, roll back the transaction
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
            finally {
                unitOfWork.Dispose();
            }
        }
        else
            await next(context);
    }
    private bool IsTransactionRequired(HttpContext context) {
        var requestMethod = context.Request.Method;
        return requestMethod.Equals(HttpMethod.Post.Method, StringComparison.OrdinalIgnoreCase) ||
               requestMethod.Equals(HttpMethod.Put.Method, StringComparison.OrdinalIgnoreCase) ||
               requestMethod.Equals(HttpMethod.Patch.Method, StringComparison.OrdinalIgnoreCase) ||
               requestMethod.Equals(HttpMethod.Delete.Method, StringComparison.OrdinalIgnoreCase);
    }
}

public static class TransactionMiddlewareExtension {
    public static IApplicationBuilder UseTransactionMiddleware(this IApplicationBuilder builder) {
        return builder.UseMiddleware<TransactionMiddleware>();
    }
}