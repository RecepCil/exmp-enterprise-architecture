using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Northwind.MvcWebUI.Infrastructure
{
    //Burası bize, Client için EndPoint(Proxy) create edecek
    public static class WcfProxy<T>
    {
        public static T CreateChannel()
        {
            //Çalıştığında gelen servis'in localhostunun port numarasını alıyoruz
            string address = String.Format("http://localhost:52771/{0}.svc?wsdl", typeof(T).Name.Substring(1)); //A

            var binding = new BasicHttpBinding();                               //B

            //a ve b'yi kullanarak kontratı ayağa kaldırıcam
            //Bu binding ve address'e göre bir kanal(proxy) döndür
            var channel = new ChannelFactory<T>(binding,address);
            return channel.CreateChannel();
        }
     

        //public static IProductService CreateChannel()
        //{
        //    string address = "http://localhost:52771/ProductService.svc?wsdl";

        //    var binding = new BasicHttpBinding();

        //    var channel = new ChannelFactory<IProductService>(binding, address);

        //    return channel.CreateChannel();
        //}





    }
}