using Library.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class LibraryContext : IdentityDbContext<User, Role, int>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API commands
            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>((int)RoleValue.User)
            .HasValue<Student>((int)RoleValue.Student)
            .HasValue<Reader>((int)RoleValue.Reader)
            .HasValue<Teacher>((int)RoleValue.Teacher)
            .HasValue<Admin>((int)RoleValue.Admin);



            //seedowanie danych

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Name = "Harry Potter i Kamieñ Filozoficzny",
                Author = "J.K. Rowling",
                Genre = "Literatura m³odzie¿owa",
                ShortDescription = "Harry Potter, sierota i podrzutek, od niemowlêcia wychowywany by³ przez ciotkê i wuja, którzy traktowali go jak pi¹te ko³o u wozu. Pochodzenie ch³opca owiane jest tajemnic¹; jedyn¹ pami¹tk¹ Harry`ego z przesz³oœci jest zagadkowa blizna na czole.",
                LongDescription = "Harry Potter, sierota i podrzutek, od niemowlêcia wychowywany by³ przez ciotkê i wuja, którzy traktowali go jak pi¹te ko³o u wozu. Pochodzenie ch³opca owiane jest tajemnic¹; jedyn¹ pami¹tk¹ Harry`ego z przesz³oœci jest zagadkowa blizna na czole. Sk¹d jednak bior¹ siê niesamowite zjawiska, które towarzysz¹ nieœwiadomemu niczego Potterowi? Wszystko zmienia siê w dniu jedenastych urodzin ch³opca, kiedy dowiaduje siê o istnieniu œwiata, o którym nie mia³ dot¹d pojêcia.Nowe wydanie ksi¹¿ki o najs³ynniejszym czarodzieju œwiata ró¿ni siê od poprzednich nie tylko ok³adk¹, ale i wnêtrzem – po raz pierwszy na pocz¹tku ka¿dego tomu pojawi siê mapka Hogwartu i okolic, pocz¹tki rozdzia³ów ozdobione bêd¹ specjalnymi gwiazdkami, a na koñcu pierwszego tomu na Czytelników czeka coœ zupe³nie wyj¹tkowego – akt personalny J.K.Rowling, z którego mo¿na dowiedzieæ siê, jakie jest ulubione zwierzê czy bohater literacki autorki.",
                Publisher = "Media Rodzina",
                Year = 1997,
                NumberOfPages = 328,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 2,
                Name = "Harry Potter i Komnata Tajemnic",
                Author = "J.K. Rowling",
                Genre = "Literatura m³odzie¿owa",
                ShortDescription = "Harry po pe³nym przygód roku w Hogwarcie spêdza nudne wakacje u Dursleyów i z utêsknieniem wyczekuje powrotu do szko³y. Sprawy jednak znacznie siê komplikuj¹, gdy pewnego dnia odwiedza go tajemniczy przybysz i ostrzega przed… powrotem do Szko³y Magii i Czarodziejstwa, gdzie ma dojœæ do strasznych wydarzeñ.",
                LongDescription = "Harry po pe³nym przygód roku w Hogwarcie spêdza nudne wakacje u Dursleyów i z utêsknieniem wyczekuje powrotu do szko³y. Sprawy jednak znacznie siê komplikuj¹, gdy pewnego dnia odwiedza go tajemniczy przybysz i ostrzega przed… powrotem do Szko³y Magii i Czarodziejstwa, gdzie ma dojœæ do strasznych wydarzeñ. Czy Harry pos³ucha ostrze¿enia? Co z³ego ma siê wydarzyæ w Hogwarcie? Jakie tajemnice skrywa rodzina Malforya? I najwa¿niejsze – czym jest i gdzie znajduje siê tytu³owa Komnata Tajemnic? Nowe wydanie ró¿ni siê od poprzednich nie tylko ok³adk¹, ale i wnêtrzem – po raz pierwszy na pocz¹tku ka¿dego tomu pojawi siê mapka Hogwartu i okolic, a pocz¹tki rozdzia³ów ozdobione bêd¹ specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 1998,
                NumberOfPages = 368,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 3,
                Name = "Harry Potter i wiêzieñ Azkabanu",
                Author = "J.K. Rowling",
                Genre = "Literatura m³odzie¿owa",
                ShortDescription = "Z pilnie strze¿onego wiêzienia dla czarodziejów ucieka niebezpieczny przestêpca. Kim jest? Co go ³¹czy z Harrym? Dlaczego lekcje przepowiadania przysz³oœci staj¹ siê dla bohatera udrêk¹?",
                LongDescription = "Z pilnie strze¿onego wiêzienia dla czarodziejów ucieka niebezpieczny przestêpca. Kim jest? Co go ³¹czy z Harrym? Dlaczego lekcje przepowiadania przysz³oœci staj¹ siê dla bohatera udrêk¹? W trzecim tomie przygód Harry`ego Pottera poznajemy nowego nauczyciela obrony przed czarn¹ magi¹, ogl¹damy Hagrida w nowej roli oraz dowiadujemy siê wiêcej o przesz³oœci profesora Snape`a. Wyprawiamy siê równie¿ wraz z trzecioklasistami do obfituj¹cego w atrakcje Hogsmeade, jedynej wioski w Anglii zamieszkanej wy³¹cznie przez czarodziejów. Nowe wydanie ksi¹¿ki o najs³ynniejszym czarodzieju œwiata ró¿ni siê od poprzednich nie tylko ok³adk¹, ale i wnêtrzem – po raz pierwszy na pocz¹tku ka¿dego tomu pojawi siê mapka Hogwartu i okolic, a pocz¹tki rozdzia³ów ozdobione bêd¹ specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 1999,
                NumberOfPages = 450,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 4,
                Name = "Harry Potter i Czara Ognia",
                Author = "J.K. Rowling",
                Genre = "Literatura m³odzie¿owa",
                ShortDescription = "W tym roku w Szkole Magii i Czarodziejstwa Hogwart rozegra siê Turniej Trójmagiczny, na który przybêd¹ uczniowie z Bu³garii i Francjii. Zgodnie z prastarymi regu³ami w turnieju uczestniczyæ ma trzech uczniów",
                LongDescription = "W tym roku w Szkole Magii i Czarodziejstwa Hogwart rozegra siê Turniej Trójmagiczny, na który przybêd¹ uczniowie z Bu³garii i Francjii. Zgodnie z prastarymi regu³ami w turnieju uczestniczyæ ma trzech uczniów - reprezentantów ka¿dej ze szkó³, wybranych przez Czarê Ognia. W tajemniczych i niewyjaœnionych okolicznoœciach wybranych zostaje czterech. Co z tego wyniknie dla Harry'ego, jego przyjació³ i ca³ego œwiata czarodziejów, dowiecie siê z lektury czwartego tomu przygód nastoletniego czarodzieja. Nowe wydanie ksi¹¿ki o najs³ynniejszym czarodzieju œwiata ró¿ni siê od poprzednich nie tylko ok³adk¹, ale i wnêtrzem – po raz pierwszy na pocz¹tku ka¿dego tomu pojawi siê mapka Hogwartu i okolic, a pocz¹tki rozdzia³ów ozdobione bêd¹ specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 2000,
                NumberOfPages = 768,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 5,
                Name = "Harry Potter i Zakon Feniksa",
                Author = "J.K. Rowling",
                Genre = "Literatura m³odzie¿owa",
                ShortDescription = "Harry znów spêdza nudne, samotne wakacje w domu Dursleyów. Czeka go pi¹ty rok nauki w Hogwarcie i chcia³by jak najszybciej spotkaæ siê ze swoimi najlepszymi przyjació³mi, Ronem i Hermion¹. Ci jednak wyraŸnie go zaniedbuj¹.",
                LongDescription = "Harry znów spêdza nudne, samotne wakacje w domu Dursleyów. Czeka go pi¹ty rok nauki w Hogwarcie i chcia³by jak najszybciej spotkaæ siê ze swoimi najlepszymi przyjació³mi, Ronem i Hermion¹. Ci jednak wyraŸnie go zaniedbuj¹. Gdy Harry ma ju¿ doœæ wszystkiego i postanawia zmieniæ swoj¹ nieznoœn¹ sytuacjê, sprawy przyjmuj¹ ca³kiem nieoczekiwany obrót. Wygl¹da na to,¿e nowy rok nauki w Hogwarcie bêdzie bardzo dramatyczny.Po raz pierwszy w ¿yciu Harry poczuje siê tam nie jak w domu, tylko… wiêzieniu, i to nie za spraw¹ przywróconego do ¿ycia Lorda Voldemorta. Nowe wydanie ksi¹¿ki o najs³ynniejszym czarodzieju œwiata ró¿ni siê od poprzednich nie tylko ok³adk¹, ale i wnêtrzem – po raz pierwszy na pocz¹tku ka¿dego tomu pojawi siê mapka Hogwartu i okolic, a pocz¹tki rozdzia³ów ozdobione bêd¹ specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 2003,
                NumberOfPages = 960,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 6,
                Name = "Harry Potter i Ksi¹¿ê Pó³krwi",
                Author = "J.K. Rowling",
                Genre = "Literatura m³odzie¿owa",
                ShortDescription = "Po nieudanej próbie przechwycenia przepowiedni Lord Voldemort jest gotów uczyniæ wszystko, by zaw³adn¹æ œwiatem czarodziejów. Organizuje tajemny zamach na swego przeciwnika, a narzêdziem w jego rêku staje siê jeden z uczniów. Czy jego plan siê powiedzie?",
                LongDescription = "Po nieudanej próbie przechwycenia przepowiedni Lord Voldemort jest gotów uczyniæ wszystko, by zaw³adn¹æ œwiatem czarodziejów. Organizuje tajemny zamach na swego przeciwnika, a narzêdziem w jego rêku staje siê jeden z uczniów. Czy jego plan siê powiedzie? Szósta czêœæ przygód Harry’ego Pottera przynosi cenne informacje o matce Voldemorta, jego dzieciñstwie oraz pocz¹tkach kariery m³odego Toma Riddle’a, które rzuc¹ nowe œwiat³o na sylwetkê g³ównego antagonisty Pottera. Na czym polega sekret nadprzyrodzonej mocy Czarnego Pana ? Jaki jest cel tajemniczych i niebezpiecznych wypraw Dumbledore’a ? I wreszcie, kto jest tytu³owym Ksiêciem Pó³krwi i jak¹ misjê ma on do spe³nienia? Nowe wydanie ksi¹¿ki o najs³ynniejszym czarodzieju œwiata ró¿ni siê od poprzednich nie tylko ok³adk¹, ale i wnêtrzem – po raz pierwszy na pocz¹tku ka¿dego tomu pojawi siê mapka Hogwartu i okolic, a pocz¹tki rozdzia³ów ozdobione bêd¹ specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 2005,
                NumberOfPages = 704,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 7,
                Name = "Harry Potter i Insygnia Œmierci",
                Author = "J.K. Rowling",
                Genre = "Literatura m³odzie¿owa",
                ShortDescription = "Po œmierci Dumbledore'a Zakon Feniksa wzmaga swoj¹ dzia³alnoœæ, próbuj¹c przeciwstawiæ siê coraz potê¿niejszym si³om œmiercio¿erców. Harry wraz z przyjació³mi nie wraca do Hogwartu, tylko wyrusza z misj¹ znalezienia sposobu na pokonanie Voldemorta.",
                LongDescription = "Po œmierci Dumbledore'a Zakon Feniksa wzmaga swoj¹ dzia³alnoœæ, próbuj¹c przeciwstawiæ siê coraz potê¿niejszym si³om œmiercio¿erców. Harry wraz z przyjació³mi nie wraca do Hogwartu, tylko wyrusza z misj¹ znalezienia sposobu na pokonanie Voldemorta. Wyprawa ta pe³na niepewnoœci i zw¹tpienia naje¿ona jest niebezpieczeñstwami, a co gorsza nikt nie wie, czy zakoñczy siê sukcesem i czy wszyscy dotrwaj¹ do jej koñca. Dlaczego Dumbledore nie pozostawi³ Harry`emu czytelnych wskazówek ? Czy przesz³oœæ nie¿yj¹cego dyrektora kryje jakieœ niezwyk³e tajemnice ? Jak¹ rolê odegra Snape przy boku Voldemorta ? Czy Harry`emu uda siê dotrzeæ do najwa¿niejszych miejsc i faktów dotycz¹cych jego rodziny? Siódmy tom przyniesie odpowiedzi na wszystkie istotne dla potteromaniaków pytania. Nowe wydanie ksi¹¿ki o najs³ynniejszym czarodzieju œwiata ró¿ni siê od poprzednich nie tylko ok³adk¹, ale i wnêtrzem – po raz pierwszy na pocz¹tku ka¿dego tomu pojawi siê mapka Hogwartu i okolic, a pocz¹tki rozdzia³ów ozdobione bêd¹ specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 2007,
                NumberOfPages = 782,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 8,
                Name = "1984",
                Author = "George Orwell",
                Genre = "Literatura piêkna",
                ShortDescription = "Najwa¿niejsz¹ i chyba najs³ynniejsz¹ ksi¹¿k¹ Orwella jest 1984. Ta ponura antyutopia rozgrywa siê w rz¹dzonym przez totalitarny re¿im Wielkiego Brata Londynie, a ca³y œwiat podzielony jest na trzy walcz¹ce ze sob¹ bloki pañstw-supermocarstw.",
                LongDescription = "Najwa¿niejsz¹ i chyba najs³ynniejsz¹ ksi¹¿k¹ Orwella jest 1984. Ta ponura antyutopia rozgrywa siê w rz¹dzonym przez totalitarny re¿im Wielkiego Brata Londynie, a ca³y œwiat podzielony jest na trzy walcz¹ce ze sob¹ bloki pañstw-supermocarstw. Choæ mo¿e to wcale nieprawda. Bowiem w œwiecie 1984 s³owa straci³y ju¿ swoje znaczenie, a dwa plus dwa nie musi ju¿ równaæ siê cztery. Wszak g³ówny bohater powieœci Winston Smith pracuje w Ministerstwie Prawdy, które zajmuje siê manipulacj¹, propagand¹ i dezinformacj¹. A dzia³a jeszcze Ministerstwo Pokoju, które zajmuje siê Wojn¹. Ministerstwo Mi³oœci przeœladowaniem obywateli, utrzymywaniem przy pomocy si³y porz¹dku, egzekucjami i torturami. A Ministerstwo Obfitoœci – rozdawaniem g³odowych racji dla mot³ochu. Pewnie nie wszystkie cechy tego Orwellowskiego systemu dostrzegamy w naszej rzeczywistoœci, ale wiele z nich ci¹gle siê nam we wspó³czesnym œwiecie objawia.I nie chodzi tylko o Pó³nocn¹ Koreê! Musicie kupiæ tê ksi¹¿kê, bo mo¿e ju¿ nied³ugo – jak za czasów PRL – bêdzie zakazana!",
                Publisher = "Vis-á-Vis/Etiuda",
                Year = 1949,
                NumberOfPages = 240,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 9,
                Name = "Dziewczyna z poci¹gu",
                Author = "Paula Hawkins",
                Genre = "Krymina³, sensacja, thriller",
                ShortDescription = "¯ycie Rachel wydaje siê zwyczajne. Ka¿dego dnia kobieta jedzie do pracy tym samym poci¹giem. Ka¿dego dnia poci¹g zatrzymuje siê w tych samych miejscach. Jest wœród nich semafor przed pewnym szeregiem domostw.",
                LongDescription = "¯ycie Rachel wydaje siê zwyczajne. Ka¿dego dnia kobieta jedzie do pracy tym samym poci¹giem. Ka¿dego dnia poci¹g zatrzymuje siê w tych samych miejscach. Jest wœród nich semafor przed pewnym szeregiem domostw.Rachel ka¿dego ranka widuje te same postaci.Sprawia to, ¿e kobiecie wydaje siê, ¿e zna ludzi, których ¿ycie podgl¹da z okien poci¹gu.Te kilka minut dziennie stycznoœci sprawia, ¿e Rachel uwa¿a, ¿e prowadz¹ oni doskona³e ¿ycie.Marzy o tym, by równie¿ jej ¿ywot by³ taki, jak znajomych - nieznajomych zza okna. Któregoœ dnia widzi coœ wstrz¹saj¹cego.W zasadzie nie jest pewna, co zobaczy³a, gdy¿ poci¹g ruszy³.Co zrobi Rachel ? Czy alkoholiczka jest wiarygodnym œwiadkiem ? Czy wykorzysta mo¿liwoœæ pojawienia siê w ¿yciu osób, które widywa³a jedynie przez okno poci¹gu ? Postaæ g³ównej bohaterki jest doœæ kontrowersyjna i opinie Czytelników s¹ podzielone.Przekonaj siê sam i oceñ, czy ksi¹¿ka, któr¹ polecaj¹ wielkie nazwiska w œwiecie sensacji i krymina³u spodoba siê równie¿ Tobie!",
                Publisher = "Œwiat Ksi¹¿ki",
                Year = 2015,
                NumberOfPages = 328,
                Count = 3
            });
        }
    }
}