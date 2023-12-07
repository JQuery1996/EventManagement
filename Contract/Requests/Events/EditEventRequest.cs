using System.ComponentModel.DataAnnotations;
using Application.Attributes.Validations;

namespace Contract.Requests.Events; 
public class EditEventRequest {
    [MinLength(5)]
    [MaxLength(50)]
    public string? NameEn { get; init; }
    
    [MinLength(5)]
    [MaxLength(50)]
    public string? NameAr { get; init; }
    
    [MinLength(5)]
    [MaxLength(200)]
    public string? DescriptionEn { get; init; } 


    [MinLength(5)]
    [MaxLength(200)]
    public string? DescriptionAr { get; init; }
    
    
    [MinLength(5)]
    [MaxLength(50)]
    public string? Location { get; init; }
    
    
    [Range(1, int.MaxValue, ErrorMessage = "AvailableTickets must be greater than 0")]
    public int? AvailableTickets { get; init; }
    
    
    [FutureDate(ErrorMessage = "Event Date must be greater than the current date")]
    public DateTime? Date { get; init; }
    
}

