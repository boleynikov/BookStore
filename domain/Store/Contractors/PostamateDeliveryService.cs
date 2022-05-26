using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contractors
{
    public class PostamateDeliveryService : IDeliveryService
    {
        private static IReadOnlyDictionary<string, string> cities = new Dictionary<string, string>
        {
            { "1", "Київ" },
            { "2", "Харків" }
        };

        private static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> postamates = new Dictionary<string, IReadOnlyDictionary<string, string>>
        {
            {
                "1",
                new Dictionary<string, string>
                {
                    { "1", "Оболонь" },
                    { "2", "Хрещатик" },
                    { "3", "Майдан Незалежності" },
                }
            },
            {
                "2",
                new Dictionary<string, string>
                {
                    { "4", "Держпром" },
                    { "5", "Олексіївка" },
                    { "6", "Нікольский" },
                }
            }
        };

        public string UniqueCode => "Postamate";

        public string Title => "Доставка до Киева, Харкова, Кропивницького";

        public OrderDelivery GetDelivery(Form form)
        {
            if(form.UniqueCode != UniqueCode && !form.IsFinal)
            {
                throw new InvalidOperationException("Invalid form");
            }

            var cityId = form.Fields
                             .Single(field => field.Name == "city")
                             .Value;
            var cityName = cities[cityId];
            var postamateId = form.Fields
                                  .Single(field => field.Name == "postamate")
                                  .Value;
            var postamateName = postamates[cityId][postamateId];
            var parametrs = new Dictionary<string, string>
            {
                { nameof(cityId), cityId },
                { nameof(cityName), cityName },
                { nameof(postamateId), postamateId },
                { nameof(postamateName), postamateName },
            };

            var description = $"Місто: {cityName}\nПоштамат: {postamateName}";

            return new OrderDelivery(UniqueCode, description, 150m, parametrs);
        }

        public Form CreateForm(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return new Form(UniqueCode, order.Id, 1, false, new[]
            {
                new SelectionField("Місто", "city", "1", cities),
            });
        }

        public Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> values)
        {
            if (step == 1)
            {
                if (values["city"] == "1")
                {
                    return new Form(UniqueCode, orderId, 2, false, new Field[]
                    {
                        new HiddenField("Місто", "city", "1"),
                        new SelectionField("Поштамат", "postamate", "1", postamates["1"]),
                    });
                }
                else if (values["city"] == "2")
                {
                    return new Form(UniqueCode, orderId, 2, false, new Field[]
                    {
                        new HiddenField("Місто", "city", "2"),
                        new SelectionField("Поштамат", "postamate", "4", postamates["2"]),
                    });
                }
                else
                    throw new InvalidOperationException("Invalid postamate city.");
            }
            else if (step == 2)
            {
                return new Form(UniqueCode, orderId, 3, true, new Field[]
                {
                    new HiddenField("Місто", "city", values["city"]),
                    new HiddenField("Поштамат", "postamate", values["postamate"]),
                });
            }
            else
                throw new InvalidOperationException("Invalid postamate step.");
        }
    }
}
