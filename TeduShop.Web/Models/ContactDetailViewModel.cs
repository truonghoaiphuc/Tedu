using System.ComponentModel.DataAnnotations;

namespace TeduShop.Web.Models
{
    public class ContactDetailViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Tên không được trống")]
        public string Name { get; set; }
        [MaxLength(250,ErrorMessage ="Số điện thoại không được vượt quá 250 kí tự")]
        public string Phone { get; set; }
        [MaxLength(250, ErrorMessage = "Email không được vượt quá 250 kí tự")]
        public string Email { get; set; }
        [MaxLength(250, ErrorMessage = "Website không được vượt quá 250 kí tự")]
        public string Website { get; set; }
        [MaxLength(250, ErrorMessage = "Địa chỉ không được vượt quá 250 kí tự")]
        public string Address { get; set; }

        public string Other { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public bool Status { get; set; }
    }
}