using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.EF.Migrations
{
    public partial class AddNewBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Knuth began the project, originally conceived as a single book with twelve chapters, in 1962. The first three volumes of what was then expected to be a seven-volume set were published in 1968, 1969, and 1973. Work began in earnest on Volume 4 in 1973, but was suspended in 1977 for work on typesetting prompted by the second edition of Volume 2. Writing of the final copy of Volume 4A began in longhand in 2001, and the first online pre-fascicle, 2A, appeared later in 2001.[1] The first published installment of Volume 4 appeared in paperback as Fascicle 2 in 2005.");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "As the application of object technology--particularly the Java programming language--has become commonplace, a new problem has emerged to confront the software development community. Significant numbers of poorly designed programs have been created by less-experienced developers, resulting in applications that are inefficient and hard to maintain and extend. Increasingly, software system professionals are discovering just how difficult it is to work with these inherited, \"non - optimal\" applications. For several years, expert-level object programmers have employed a growing collection of techniques to improve the structural integrity and performance of such existing software programs. Referred to as \"refactoring,\" these practices have remained in the domain of experts because no attempt has been made to transcribe the lore into a form that all developers could use");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "The authors present the complete guide to ANSI standard C language programming. Written by the developers of C, this new version helps readers keep up with the finalized ANSI standard for C while showing how to take advantage of C's rich set of operators, economy of expression, improved control flow, and data structures. The 2/E has been completely rewritten with additional examples and problem sets to clarify the implementation of difficult language constructs. For years, C programmers have let K&R guide them to building well-structured and efficient programs. Now this same help is available to those working with ANSI compilers. Includes detailed coverage of the C language plus the official C language reference manual for at-a-glance help with syntax notation, declarations, ANSI changes, scope rules, and the list goes on and on.");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Image", "Isbn", "Price", "Title" },
                values: new object[,]
                {
                    { 4, "Лоран Гунель", "Всесвітньо відомий бестселер Amazon, який вже планують екранізувати, - книга «Бог завжди подорожує інкогніто» українською мовою тепер вийшла у видавництві «Клуб Сімейного Дозвілля»! Алан Грінмор — пересічний молодий чоловік. Він має вельми непогану роботу, яка, втім, його дратує, а нещодавно зненацька його кинула кохана дівчина. Життя здається сірим та безнадійним. Лише один крок відділяє його від стрибка з Ейфелевої вежі, коли один загадковий незнайомець рятує його від смерті. Відтепер між ними укладена угода — на знак вдячності за спасіння, Алан обіцяє виконувати різноманітні завдання, які дивовижним чином змінюють його життя. Тепер він краще розуміє колег, мотиви вчинків оточуючих і щиро переймається проблемами власної компанії. Але ким був той загадковий незнайомець?", "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/i/m/img293_42.jpg", "ISBN0131139671", 180m, "Бог завжди подорожує інкогніто" },
                    { 5, "Джордж Орвелл", "«1984». Книга, про яку багато говорили колись - і багато говорять зараз. Книга, що стала своєрідним «антифоном» для другої великої антиутопії XX ст. - «Прекрасний новий світ» Олдоса Гакслі. Що, по суті, страшніше - доведене до абсолюту «суспільство споживання» чи доведене до абсолюту «суспільство ідеї»? За Орвеллом, немає і не може бути нічого гіршого тотальної несвободи... \"Ферма тварин\". Гумор. Сарказм. Притча, яка змогла прийняти форму «іронічної антиутопії». Чи може скромна ферма стати символом тоталітарного суспільства? Звісно так. Але... яким побачать це суспільство його «громадяни» - тварини, приречені на бойню?", "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/i/m/img_49791.jpg", "ISBN0131401655", 185m, "Книга 1984. Скотный двор" },
                    { 6, "Роальд Дал", "Всем поклонникам творчества суперпопулярной Джоан Роулинг, без сомнения, будет интересно познакомиться с этой книгой, автора которой, Роальда Дала, принято считать «литературным отцом» знаменитой писательницы. Хотя, возможно, этот сюжет вам уже знаком, ведь «Чарли и шоколадная фабрика» - самая популярная книга Дала. Бедному мальчику, на каждый день рождения получавшему в подарок лишь маленький шоколадный батончик, предстоит удивительное приключение, ведь его доброта служит примером для других, а добро всегда получает свою награду.", "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/5/3/53225_28767120.jpg", "ISBN0187259640", 175m, "Книга Чарлі і шоколадна фабрика" },
                    { 7, "Анджей Сапковський", "Біловолосий відьмак Ґеральт із Рівії, один з небагатьох представників колись численного цеху захисників людської раси від породжень нелюдського зла, мандрує невеликими королівствами, які можна охопити поглядом з вежі замку, та великими містами, отримуючи платню за те, чого навчений, - знищення віїв і з'ядарок, стриґ та віпперів. Але є у відьмака і власний кодекс, у якому вбивство - це лише крайня міра, а життя розумне, чим би воно не було, - це все-таки життя. Саме цим він наживає собі нових ворогів, але й знаходить друзів, які колись змінять його долю.", "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/6/1/616607_front.jpg", "ISBN0119456822", 210m, "Книга Відьмак. Останнє бажання. Книга 1" },
                    { 8, "Анджей Сапковський", "Тепер Ґеральт знає, що таке кохання, знає, що він здатен на людські почуття і на найбільшу самопожертву… У його житті з’являється маленька зеленоока Цірі. На королівства, які століттями воювали лише за перенесення межових знаків, нападає страшний ворог із-за південних гір. І відьмаку все одно: чия ллється кров — людей, дріад чи ельфів…", "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/3/7/37390_67365.jpg", "ISBN0556639788", 210m, "Книга Відьмак. Меч призначення" },
                    { 9, "Анджей Сапковський", "Героїчна сага Анджея Сапковського про відьмака Ґеральта посідає четверте місце за накладами у Польщі, нагороджена преміями імені Януша Зайделя, преміями SFinks, а 2010 року автор отримав почесну нагороду Європейського співтовариства наукової фантастики EuroCon «Ґранд Майстер». Маленька Цірі — дитя-несподіванка — стала більшою несподіванкою, ніж видавалось спочатку. Жахливі сни про загибель Цінтри руйнують її душу, а чаклунський дар, що народжується, може зруйнувати тіло. Дати йому раду під силу лише могутній чарівниці Йеннефер. Тож Ґеральту не вдається довго переховувати Цірі у Відьмачому Оселищі.", "https://img.yakaboo.ua/media/catalog/product/cache/1/image/546x/c239772940bfb0468bd568cd18249fe5/3/8/38505_57981_1.jpg", "ISBN1302795771", 210m, "Книга Відьмак. Кров ельфів. Книга 3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "This volume begins with basic programming concepts");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "As the application of object technology--");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Known as the bible of C, this classic bestseller");
        }
    }
}
