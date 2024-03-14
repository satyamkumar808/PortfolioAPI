using DAL.ValidationAttributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Project
    {
        public int Id { get; set; }

        /// <summary>
        /// Need to disable empty string values currentlly not working.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage ="Name value cannot be null")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [NotAllowEmptyString]
        public string Name { get; set; }

        public string Description { get; set; }
        public string GitLink { get; set; }
    }
}
