namespace TeamUp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Img
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
