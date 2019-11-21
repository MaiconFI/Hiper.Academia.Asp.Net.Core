using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Web.Models.Base
{
    public class BaseViewModel
    {
        public ICollection<string> Errors { get; set; }
    }
}