using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.ModelBinders
{
    public class CartModelBinder : IModelBinder
    {
        //Eğer biri senden parametre olarak Cart nesnesi isterse, ona CartModelBinder'ı ver.
        //Global.asax'da konf. ayarları var.
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = (Cart)controllerContext.HttpContext.Session["cart"];

            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session["Cart"] = cart;
            }

            return cart;

        }
    }
}