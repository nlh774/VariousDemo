using System.Web.Mvc;

namespace BaseUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Menus = @"<?xml version='1.0' encoding='utf-8'?><tree id='0'><!--text是菜单按钮名。id是含路径url,菜单页面名,唯一标识。其他属性如open,im1等是相同的--><item text='操作' id='1' open='1' im0='leaf.gif' im1='folderOpen.gif' im2='folderClosed.gif'><item text='系统账户维护' id='/Account/Index_系统账户维护_12' open='1' im0='leaf.gif' im1='folderOpen.gif' im2='folderClosed.gif'></item><item text='消息查询' id='/Message/Index_消息查询_13' open='1' im0='leaf.gif' im1='folderOpen.gif' im2='folderClosed.gif'></item></item></tree>";
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}
