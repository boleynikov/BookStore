using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Data.EF
{
    public class StoreDbContext : DbContext
    {
        public DbSet<BookDto> Books { get; set; }

        public DbSet<OrderDto> Orders { get; set; }

        public DbSet<OrderItemDto> OrderItems { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildBooks(modelBuilder);
            BuildOrders(modelBuilder);
            BuildOrderItems(modelBuilder);
        }

        private static void BuildOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDto>(action =>
            {
                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasOne(dto => dto.Order)
                      .WithMany(dto => dto.Items)
                      .IsRequired();
            });
        }

        private static void BuildOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDto>(action =>
            {
                action.Property(dto => dto.CellPhone)
                      .HasMaxLength(20);

                action.Property(dto => dto.DeliveryUniqueCode)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryPrice)
                      .HasColumnType("money");

                action.Property(dto => dto.PaymentServiceName)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);

                action.Property(dto => dto.PaymentParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);

            });       
        }

        private static readonly ValueComparer DictionaryComparer =
                     new ValueComparer<Dictionary<string, string>>(
                         (dictionary1, dictionary2) => dictionary1.SequenceEqual(dictionary2),
                         dictionary => dictionary.Aggregate(
                             0,
                             (a, p) => HashCode.Combine(HashCode.Combine(a, p.Key.GetHashCode(), p.Value.GetHashCode())
                                 )
                             )
                         );

        private static void BuildBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDto>(action =>
            {
                action.Property(dto => dto.Isbn)
                      .HasMaxLength(17)
                      .IsRequired();
                action.Property(dto => dto.Image);

                action.Property(dto => dto.Title)
                      .IsRequired();

                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasData(
                    new BookDto
                    {
                        Id = 1,
                        Isbn = "ISBN0201038013",
                        Image = "https://upload.wikimedia.org/wikipedia/commons/6/62/ArtOfComputerProgramming.jpg",
                        Author = "D. Knuth",
                        Title = "Art of Programming, Vol. 1",
                        Description = "Knuth began the project, originally conceived as a single book with twelve chapters, in 1962. The first three volumes of what was then expected to be a seven-volume set were published in 1968, 1969, and 1973. Work began in earnest on Volume 4 in 1973, but was suspended in 1977 for work on typesetting prompted by the second edition of Volume 2. Writing of the final copy of Volume 4A began in longhand in 2001, and the first online pre-fascicle, 2A, appeared later in 2001.[1] The first published installment of Volume 4 appeared in paperback as Fascicle 2 in 2005.",
                        Price = 690m,
                    },
                    new BookDto
                    {
                        Id = 2,
                        Isbn = "ISBN0201454816",
                        Image = "https://images-na.ssl-images-amazon.com/images/I/51k+BvsOl2L._SX392_BO1,204,203,200_.jpg",
                        Author = "M. Fowler",
                        Title = "Refactoring",
                        Description = "As the application of object technology--particularly the Java programming language--has become commonplace, a new problem has emerged to confront the software development community. Significant numbers of poorly designed programs have been created by less-experienced developers, resulting in applications that are inefficient and hard to maintain and extend. Increasingly, software system professionals are discovering just how difficult it is to work with these inherited, \"non - optimal\" applications. For several years, expert-level object programmers have employed a growing collection of techniques to improve the structural integrity and performance of such existing software programs. Referred to as \"refactoring,\" these practices have remained in the domain of experts because no attempt has been made to transcribe the lore into a form that all developers could use",
                        Price = 450m,
                    },
                    new BookDto
                    {
                        Id = 3,
                        Isbn = "ISBN0131101633",
                        Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/The_C_Programming_Language%2C_First_Edition_Cover.svg/1200px-The_C_Programming_Language%2C_First_Edition_Cover.svg.png",
                        Author = "B. W. Kernighan, D. M. Ritchie",
                        Title = "C Programminh Language",
                        Description = "The authors present the complete guide to ANSI standard C language programming. Written by the developers of C, this new version helps readers keep up with the finalized ANSI standard for C while showing how to take advantage of C's rich set of operators, economy of expression, improved control flow, and data structures. The 2/E has been completely rewritten with additional examples and problem sets to clarify the implementation of difficult language constructs. For years, C programmers have let K&R guide them to building well-structured and efficient programs. Now this same help is available to those working with ANSI compilers. Includes detailed coverage of the C language plus the official C language reference manual for at-a-glance help with syntax notation, declarations, ANSI changes, scope rules, and the list goes on and on.",
                        Price = 350m,
                    },
                    new BookDto
                    {
                        Id = 4,
                        Isbn = "ISBN0131139671",
                        Image = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/i/m/img293_42.jpg",
                        Author = "Лоран Гунель",
                        Title = "Бог завжди подорожує інкогніто",
                        Description = "Всесвітньо відомий бестселер Amazon, який вже планують екранізувати, - книга «Бог завжди подорожує інкогніто» українською мовою тепер вийшла у видавництві «Клуб Сімейного Дозвілля»! Алан Грінмор — пересічний молодий чоловік. Він має вельми непогану роботу, яка, втім, його дратує, а нещодавно зненацька його кинула кохана дівчина. Життя здається сірим та безнадійним. Лише один крок відділяє його від стрибка з Ейфелевої вежі, коли один загадковий незнайомець рятує його від смерті. Відтепер між ними укладена угода — на знак вдячності за спасіння, Алан обіцяє виконувати різноманітні завдання, які дивовижним чином змінюють його життя. Тепер він краще розуміє колег, мотиви вчинків оточуючих і щиро переймається проблемами власної компанії. Але ким був той загадковий незнайомець?",
                        Price = 180m,
                    },
                    new BookDto
                    {
                        Id = 5,
                        Isbn = "ISBN0131401655",
                        Image = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/i/m/img_49791.jpg",
                        Author = "Джордж Орвелл",
                        Title = "Книга 1984. Скотный двор",
                        Description = "«1984». Книга, про яку багато говорили колись - і багато говорять зараз. Книга, що стала своєрідним «антифоном» для другої великої антиутопії XX ст. - «Прекрасний новий світ» Олдоса Гакслі. Що, по суті, страшніше - доведене до абсолюту «суспільство споживання» чи доведене до абсолюту «суспільство ідеї»? За Орвеллом, немає і не може бути нічого гіршого тотальної несвободи... \"Ферма тварин\". Гумор. Сарказм. Притча, яка змогла прийняти форму «іронічної антиутопії». Чи може скромна ферма стати символом тоталітарного суспільства? Звісно так. Але... яким побачать це суспільство його «громадяни» - тварини, приречені на бойню?",
                        Price = 185m,
                    },
                    new BookDto
                    {
                        Id = 6,
                        Isbn = "ISBN0187259640",
                        Image = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/5/3/53225_28767120.jpg",
                        Author = "Роальд Дал",
                        Title = "Книга Чарлі і шоколадна фабрика",
                        Description = "Всем поклонникам творчества суперпопулярной Джоан Роулинг, без сомнения, будет интересно познакомиться с этой книгой, автора которой, Роальда Дала, принято считать «литературным отцом» знаменитой писательницы. Хотя, возможно, этот сюжет вам уже знаком, ведь «Чарли и шоколадная фабрика» - самая популярная книга Дала. Бедному мальчику, на каждый день рождения получавшему в подарок лишь маленький шоколадный батончик, предстоит удивительное приключение, ведь его доброта служит примером для других, а добро всегда получает свою награду.",
                        Price = 175m,
                    },
                    new BookDto
                    {
                        Id = 7,
                        Isbn = "ISBN0119456822",
                        Image = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/6/1/616607_front.jpg",
                        Author = "Анджей Сапковський",
                        Title = "Книга Відьмак. Останнє бажання. Книга 1",
                        Description = "Біловолосий відьмак Ґеральт із Рівії, один з небагатьох представників колись численного цеху захисників людської раси від породжень нелюдського зла, мандрує невеликими королівствами, які можна охопити поглядом з вежі замку, та великими містами, отримуючи платню за те, чого навчений, - знищення віїв і з'ядарок, стриґ та віпперів. Але є у відьмака і власний кодекс, у якому вбивство - це лише крайня міра, а життя розумне, чим би воно не було, - це все-таки життя. Саме цим він наживає собі нових ворогів, але й знаходить друзів, які колись змінять його долю.",
                        Price = 210m,
                    },
                    new BookDto
                    {
                        Id = 8,
                        Isbn = "ISBN0556639788",
                        Image = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/3/7/37390_67365.jpg",
                        Author = "Анджей Сапковський",
                        Title = "Книга Відьмак. Меч призначення",
                        Description = "Тепер Ґеральт знає, що таке кохання, знає, що він здатен на людські почуття і на найбільшу самопожертву… У його житті з’являється маленька зеленоока Цірі. На королівства, які століттями воювали лише за перенесення межових знаків, нападає страшний ворог із-за південних гір. І відьмаку все одно: чия ллється кров — людей, дріад чи ельфів…",
                        Price = 210m,
                    },
                    new BookDto
                    {
                        Id = 9,
                        Isbn = "ISBN1302795771",
                        Image = "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/3/8/38505_57981_1.jpg",
                        Author = "Анджей Сапковський",
                        Title = "Книга Відьмак. Кров ельфів. Книга 3",
                        Description = "Героїчна сага Анджея Сапковського про відьмака Ґеральта посідає четверте місце за накладами у Польщі, нагороджена преміями імені Януша Зайделя, преміями SFinks, а 2010 року автор отримав почесну нагороду Європейського співтовариства наукової фантастики EuroCon «Ґранд Майстер». Маленька Цірі — дитя-несподіванка — стала більшою несподіванкою, ніж видавалось спочатку. Жахливі сни про загибель Цінтри руйнують її душу, а чаклунський дар, що народжується, може зруйнувати тіло. Дати йому раду під силу лише могутній чарівниці Йеннефер. Тож Ґеральту не вдається довго переховувати Цірі у Відьмачому Оселищі.",
                        Price = 210m,
                    });
            });
        }
    }
}

