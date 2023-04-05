using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IWebRepository
    {
        WebViewModel CreateViewModel(string url);
    }
}