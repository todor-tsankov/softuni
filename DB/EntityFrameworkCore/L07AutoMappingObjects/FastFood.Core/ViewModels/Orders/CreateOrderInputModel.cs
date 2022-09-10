using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Orders
{
    public class CreateOrderInputModel
    {
        [Required, StringLength(30, MinimumLength = 3)]
        public string Customer { get; set; }

        [Required]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
