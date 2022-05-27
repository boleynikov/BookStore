using Microsoft.AspNetCore.Http;
using Store.Contractors;
using Store.Web.Contractors;
using System;
using System.Collections.Generic;

namespace Store.OshadBank
{
    public class OshadbankPaymentService : IPaymentService, IWebContractorService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public OshadbankPaymentService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        private HttpRequest Request => httpContextAccessor.HttpContext.Request;

        public string Name => "Oshadbank";

        public string Title => "Оплата банківською картою";

        public Form FirstForm(Order order)
        {
            return Form.CreateFirst(Name)
                       .AddParameter("orderId", order.Id.ToString());
        }

        public Form NextForm(int step, IReadOnlyDictionary<string, string> values)
        {
            if (step != 1)
                throw new InvalidOperationException("Invalid Oshadbank payment step.");

            return Form.CreateLast(Name, step + 1, values);
        }

        public OrderPayment GetPayment(Form form)
        {
            if (form.ServiceName != Name || !form.IsFinal)
                throw new InvalidOperationException("Invalid payment form.");

            return new OrderPayment(Name, "Оплата картою", form.Parameters);
        }

        public Uri StartSession(IReadOnlyDictionary<string, string> parameters, Uri returnUri)
        {
            var queryString = QueryString.Create(parameters);
            queryString += QueryString.Create("returnUri", returnUri.ToString());

            var builder = new UriBuilder(Request.Scheme, Request.Host.Host)
            {
                Path = "Oshadbank/",
                Query = queryString.ToString(),
            };

            if (Request.Host.Port != null)
                builder.Port = Request.Host.Port.Value;

            return builder.Uri;
        }
    }
}