using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Northwind.MvcWebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo pagingInfo,int category)
        {
            //Tag builder ile  "0", "1", "2" gibi tüm tagleri yaratıp,
            //Onlara href atayıp,
            //String Builder ile hepsini birleştiriyorum.

            //totalPage'i hesaplamamın sebebi de kaç tane tag koyacak olmamı bilmek

            int totalPage = (int)Math.Ceiling
                ((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage);

            var stringBuilder = new StringBuilder();
            for(int i = 1 ; i < totalPage ; i++)
            {
                var tagBuilder = new TagBuilder("a");
                tagBuilder.MergeAttribute("href",String.Format("/Product/Index/?category={0}&page={1}",category,i));
                tagBuilder.InnerHtml = i.ToString();

                //kullanıcının üzerine geldiği tagin css'ini selected yap
                if (pagingInfo.CurrentPage == i)
                {
                    tagBuilder.AddCssClass("selected");
                }

                stringBuilder.Append(tagBuilder);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        public static MvcHtmlString RecoButton(this HtmlHelper helper, string id = "", string buttonClass = "", ButtonType type = ButtonType.Button, string text = "")
        {
            TagBuilder tagButton = new TagBuilder("button");
            tagButton.AddCssClass(buttonClass);
            tagButton.GenerateId(id+"Burası id");
            tagButton.SetInnerText(text + "Burası text");
            tagButton.Attributes.Add("type", ButtonType.Button.ToString());
            tagButton.Attributes.Add("name", id);

            return MvcHtmlString.Create(tagButton.ToString());

        }
    }
}