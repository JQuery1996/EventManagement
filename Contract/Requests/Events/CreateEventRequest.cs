using System.ComponentModel.DataAnnotations;
using Application.Attributes.Validations;

namespace Contract.Requests.Events;

public class CreateEventRequest {
    [Required(ErrorMessage = "Event NameEn is required")]
    [MinLength(5)]
    [MaxLength(50)]
    public string NameEn { get; init; } = null!;
    
    [Required(ErrorMessage = "Event NameAr is required")]
    [MinLength(5)]
    [MaxLength(50)]
    public string NameAr { get; init; } = null!;
    
    [Required(ErrorMessage = "Event DescriptionEn is required")]
    [MinLength(5)]
    [MaxLength(200)]
    public string DescriptionEn { get; init; } = null!;


    [Required(ErrorMessage = "Event DescriptionAr is required")]
    [MinLength(5)]
    [MaxLength(200)]
    public string DescriptionAr { get; init; } = null!;
    
    
    [Required(ErrorMessage = "Event Location is required")]
    [MinLength(5)]
    [MaxLength(50)]
    public string Location { get; init; } = null!;
    
    
    [Required(ErrorMessage = "Event AvailableTickets is required")]
    [Range(1, int.MaxValue, ErrorMessage = "AvailableTickets must be greater than 0")]
    public int AvailableTickets { get; init; }
    
    
    [Required(ErrorMessage = "Event Date is required")]
    [FutureDate(ErrorMessage = "Event Date must be greater than the current date")]
    public DateTime Date { get; init; }
    
}

