//StoreShop apk


//Predefinirana sifra za ulaz u neke naredbe je "StoreShop"


List<string> names = new List<string>()
{
    "jabuka",
    "banana",
    "jogurt",
    "mljeveno meso",
    "vodka smirnoff",
    "HB olovka"
};
List<float> data = new List<float>()
{
    343, 0.67f,
    279, 0.87f,
    98, 2.5f,
    51, 4.98f,
    127, 18.07f,
    76, 1.43f
};
List<DateTime> deadline = new List<DateTime>()
{
    DateTime.Parse("03/03/2024"),
    DateTime.Parse("01/13/2024"),
    DateTime.Parse("12/19/2023"),
    DateTime.Parse("12/01/2023"),
    DateTime.Parse("09/22/2026"),
    DateTime.Parse("04/05/2031")
};
List<DateTime> birth = new List<DateTime>()
{
    DateTime.Parse("04/07/1937"),
    DateTime.Parse("12/13/1974"),
    DateTime.Parse("09/27/1976")
};
List<string> e_names = new List<string>()
{
    "Pajo Patak",
    "Miss Piggy",
    "Kermit"
};
List<DateTime> taxes_dt = new List<DateTime>()
{
    DateTime.Parse("11/07/2022"),
    DateTime.Parse("12/13/2022"),
    DateTime.Parse("05/18/2022"),
    DateTime.Parse("09/12/2023"),
    DateTime.Parse("12/24/2023"),
    DateTime.Parse("09/27/2023")
};
List<float> taxes_p = new List<float>()
{
    24.9f+15.73f,
    10.44f+8.04f,
    18.07f+0.67f+4.98f,
    10.0f+1.43f*9,
    4.98f*8,
    1.43f*11

};
List<string> arts = new List<string>()
{
    "mljeveno meso",    //prvi racun
    "HB olovka",        //prvi racun
    "banana",           //drugi racun
    "jabuka",           //drugi racun
    "vodka smirnoff",   //treci racun
    "jabuka",           //treci racun
    "mljeveno meso",    //treci racun
    "jogurt",           //cetvrti racun
    "HB olovka",        //cetvrti racun
    "mljeveno meso",    //peti racun
    "HB olovka"         //sesti racun
};
List<float> ams = new List<float>()
{
    5,
    11,
    12,
    12,
    1,
    1,
    1,
    4,
    9,
    8,
    11
};
List<int> howMuch = new List<int>()
{
    2,
    2,
    3,
    2,
    1,
    1
};

wantMore(names, data, deadline, e_names, birth, "StoreShop", taxes_dt, taxes_p, arts, ams, howMuch);


//naslovna
static void wantMore(List<string> names, List<float> data, List<DateTime> deadline, List<string> e_names, List<DateTime> birth, string k, List<DateTime> taxes_dt, List<float> taxes_p, List<string> arts, List<float> ams, List<int> howMuch)
{
    Console.WriteLine("1 - Artikli");
    Console.WriteLine("2 - Radnici");
    Console.WriteLine("3 - Racuni");
    Console.WriteLine("4 - Statistika");
    Console.WriteLine("0 - Izlaz iz aplikacije");

    int act1 = -1;

    while (!int.TryParse(Console.ReadLine(), out act1) || !(act1 < 5 && act1 > -1))
    {
        Console.WriteLine("------------------------krivi unos------------------------");
    }
    switch (act1)
    {
        case 1:
            article(names, data, deadline, birth, e_names, taxes_dt, taxes_p, arts, ams, howMuch);
            break;
        case 2:
            employee(names, data, deadline, e_names, birth, taxes_dt, taxes_p, arts, ams, howMuch);
            break;
        case 3:
            tax(names, data, deadline, e_names, birth, "StoreShop", 1, taxes_dt, taxes_p, arts, ams, howMuch);
            break;
        case 4:
            statistic(names, data, deadline, birth, e_names, taxes_dt, taxes_p, arts, ams, howMuch);
            break;
        default:
            break;
    }

}

//artikli
static void article(List<string> names, List<float> data, List<DateTime> deadline, List<DateTime> birth, List<string> e_names, List<DateTime> taxes_dt, List<float> taxes_p, List<string> arts, List<float> ams, List<int> howMuch)
{
    
    Console.WriteLine("1 - Unos artikla\n2 - Brisanje artikla\n3 - Uredivanje artikla\n4 - Ispis");
    int act2 = -1;
    string name;
    DateTime date;
    float amount, price;
    while (!int.TryParse(Console.ReadLine(), out act2) || !(act2 < 5 && act2 > 0))
    {
        Console.WriteLine("------------------------krivi unos------------------------");
    }
    switch (act2)
    {
        case 1:
            Console.WriteLine("Upisite ime artikla, kolicinu, cijenu i datum isteka\n - MOLIM DA ROK TRAJANJA UPISETE U FORMATU MM/DD/YYYY -");
            name = Console.ReadLine();
            while(!float.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("------------------------krivi unos------------------------");
            } while (!float.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("------------------------krivi unos------------------------");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("------------------------krivi unos------------------------");
            }
            Console.WriteLine("Pritisnite enter za potvrdu unosa, pritiskom bilo koje druge tipke unos se ponistava");
            var s = Console.ReadLine();
            if (s == "")
            {
                bool inside = false;
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i] == name)
                    {
                        data[2 * i] += amount;
                        inside = true;
                    }
                }
                if (inside == false)
                {
                    Console.WriteLine(name);
                    names.Add(name);
                    data.Add(amount);
                    data.Add(price);
                    deadline.Add(date);
                }
            }
            break;
        case 2:
            int c = deadline.Count;
            Console.WriteLine("a - Brisanje artikla po imenu\nb - Brisanje artikala kojima je istekao datum trajanja");
            string act3 = Console.ReadLine();
            while (!(act3 == "a" || act3 == "b"))
            {
                Console.WriteLine("------------------------krivi unos------------------------");
                act3 = Console.ReadLine();
            }
            if (act3 == "a")
            {
                Console.WriteLine("Molimo upišite ime jednog od spremljenih artikala");
                for (int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine(names[i] + " ");
                }
                name = Console.ReadLine();
                bool notIn = true;
                while (notIn)
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (name == names[i]) notIn = false;
                    }if (notIn)
                    {
                        Console.WriteLine("------------------------krivi unos------------------------");
                        name = Console.ReadLine();
                    }
                }
                Console.WriteLine("Pritisnite enter za potvrdu unosa, pritiskom bilo koje druge tipke unos se ponistava");
                s = Console.ReadLine();
                if (s == "")
                {
                    for (int i = 0; i < c; i++)
                    {
                        if (name == names[i])
                        {
                            c--;
                            names.RemoveAt(i);
                            data.RemoveRange(2 * i, 2);
                            deadline.RemoveAt(i);
                        }
                    }
                }
            }
            else
            {
                var dateNow = DateTime.Today;
                for (int i = 0; i < c; i++)
                {
                    if (deadline[i] < dateNow)
                    {
                        c--;
                        deadline.RemoveAt(i);
                        names.RemoveAt(i);
                        data.RemoveRange(2 * i, 2);
                    }
                }
            }
            break;
        case 3:
            Console.WriteLine("a - zasebno uredivanje artikala, trazenje po imenu artikla\nb - popust/poskupljenje svih proizvoda");
            string act4 = Console.ReadLine();
            while(!(act4 == "a" || act4 == "b"))
            {
                act4 = Console.ReadLine();
                Console.WriteLine("------------------------krivi unos------------------------");
            }
            switch (act4)
            {
                case "a":
                    for (int i = 0; i < names.Count; i++)
                    {
                        Console.WriteLine(names[i] + " (" + data[2 * i].ToString() + ") - " + data[2 * i + 1].ToString() + " - ");
                        Console.WriteLine((deadline[i] - DateTime.Now).TotalDays);
                    }
                    Console.WriteLine("Sada upisite ime artikla na kojem zelite vrsiti promjene");
                    string change = Console.ReadLine();
                    bool state = false;
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (change == names[i])
                            state = true;
                    }
                    if (state == false)
                    {
                        Console.WriteLine("------------------------Upisani artikl nepostoji------------------------");
                    }
                    else
                    {
                        Console.WriteLine("Upišite:\n1 - Izmjena kolicine\n2 - Izmjena cijene\n3 - Izmjena datuma roka trajanja");
                        int act5 = -1;
                        while (!int.TryParse(Console.ReadLine(), out act5) || !(act5 < 4 && act5 > 0))
                        {
                            Console.WriteLine("------------------------krivi unos------------------------");
                        }
                        if (act5 == 1)
                        {
                            Console.WriteLine("Upisite novu kolicinu artikla");
                            float change_am = -1.0f;
                            while (!float.TryParse(Console.ReadLine(), out change_am))
                            {
                                Console.WriteLine("------------------------krivi unos------------------------");
                            }
                            for (int i = 0; i < names.Count; i++)
                            {
                                if (change == names[i])
                                {
                                    data[2 * i] = change_am;
                                }
                            }
                        }
                        else if (act5 == 2)
                        {
                            Console.WriteLine("Upisite novu cijenu artikla");
                            float change_pr = -1;
                            while (!float.TryParse(Console.ReadLine(), out change_pr))
                            {
                                Console.WriteLine("------------------------krivi unos------------------------");
                            }
                            for (int i = 0; i < names.Count; i++)
                            {
                                if (change == names[i])
                                {
                                    data[2 * i + 1] = change_pr;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Upisite novu kolicinu artikla");
                            DateTime change_dt = DateTime.Parse("00/00/0000");
                            while (!DateTime.TryParse(Console.ReadLine(), out change_dt))
                            {
                                Console.WriteLine("------------------------krivi unos------------------------");
                            }
                            for (int i = 0; i < names.Count; i++)
                            {
                                if (change == names[i])
                                {
                                    deadline[i] = change_dt;
                                }
                            }
                        }
                    }
                    break;
                case "b":
                    float percent = -1.0f;
                    Console.WriteLine("Upisite postotak (npr 73 za 73% snizenja)");
                    while (!float.TryParse(Console.ReadLine(), out percent) && !(percent > 0 && percent < 100))
                    {
                        Console.WriteLine("------------------------krivi unos------------------------");
                    }
                    for (int i = 0; i < names.Count; i++)
                    {
                        data[2 * i + 1] -= data[2 * i + 1] * percent;
                    }
                    break;
                default:
                    break;
            }
            break;
        case 4:
            Console.WriteLine("Odaberite sto zelite ispisati:\na - Sve artikle kako su spremljeni\nb - Sve artikle sortirane po imenu\nc - Sve artikle sortirane po datumu silazno\nd - Sve artikle sortirane po datumu uzlazno\ne - Sve artikle sortirane po kolicini\nf - najprodavaniji artikl\ng - najmanje prodavan artikl");
            string act6 = Console.ReadLine();
            while(!(act6 == "a" || act6 == "b" || act6 == "c" || act6 == "d" || act6 == "e" || act6 == "f" || act6 == "g"))
            {
                Console.WriteLine("------------------------krivi unos------------------------");
                act6 = Console.ReadLine();
            }output(names, data, deadline, act6, arts, ams);
            break;
        default:
            break;
    }
    wantMore(names, data, deadline, e_names, birth, "StoreShop", taxes_dt, taxes_p, arts, ams, howMuch);
}

//radnici
static void employee(List<string> names, List<float> data, List<DateTime> deadline, List<string> e_names, List<DateTime> birth, List<DateTime> taxes_dt, List<float> taxes_p, List<string> arts, List<float> ams, List<int> howMuch)
{

    Console.WriteLine("1 - Unos radnika\n2 - Brisanje radnika\n3 - Uredivanje radnika\n4 - Ispis");
    int act7 = -1;
    while (!int.TryParse(Console.ReadLine(), out act7) || !(act7 < 5 && act7 > 0))
    {
        Console.WriteLine("------------------------krivi unos------------------------");
    }
    switch (act7)
    {
        case 1:
            Console.WriteLine("Upisite ime radnika te datum i godinu rodenja (MM/DD/YYYY)");
            string name = Console.ReadLine();
            DateTime bday;
            while(!DateTime.TryParse(Console.ReadLine(), out bday))
            {
                Console.WriteLine("------------------------krivi unos------------------------");
            }birth.Add(bday);
            e_names.Add(name);
            break;
        case 2:
            Console.WriteLine("a - Brisanje radnika po imenu\nb - Brisanje svih radnika starijih od 65 godina");
            string act8 = Console.ReadLine();
            while(!(act8 == "a" || act8 == "b"))
            {
                act8 = Console.ReadLine();
                Console.WriteLine("------------------------krivi unos------------------------");
            }if(act8 == "a")
            {
                for (int i = 0; i < e_names.Count; i++)
                {
                    Console.WriteLine(e_names[i]);
                }
                Console.WriteLine("Upisite ime radnika kojeg zelite izbrisati");
                name = Console.ReadLine();
                bool isIn = false;
                while (!isIn)
                {
                    for (int i = 0; i < e_names.Count; i++)
                    {
                        if (e_names[i] == name) isIn = true;
                    }
                    if (!isIn)
                    {
                        Console.WriteLine("------------------------krivi unos------------------------");
                        name = Console.ReadLine();
                    }
                }
                int c = e_names.Count;
                for (int i = 0; i < c; i++)
                {
                    if(name == e_names[i])
                    {
                        c--;
                        e_names.RemoveAt(i);
                        birth.RemoveAt(i);
                    }
                }
            }
            else
            {
                int c = e_names.Count;
                DateTime dt = DateTime.Now;
                for(int i = 0; i < c; i++)
                {
                    if ((dt - birth[i]).TotalDays / 365.25 > 65)
                    {
                        c--;
                        birth.RemoveAt(i);
                        e_names.RemoveAt(i);
                    }
                }
            }
            break;
        case 3:
            Console.WriteLine("a - Uredivanje imena radnika\nb - Uredivanje rodenja radnika");
            string act9 = Console.ReadLine();
            while(!(act9 == "a" || act9 == "b"))
            {
                Console.WriteLine("------------------------krivi unos------------------------");
                act9 = Console.ReadLine();
            }if(act9 == "a")
            {
                for (int i = 0; i < e_names.Count; i++)
                {
                    Console.WriteLine(e_names[i]);
                }
                Console.WriteLine("Upisite ime radnika kojem zelite izmjeniti ime");
                bool exists = false;
                name = Console.ReadLine();
                while (!exists)
                {
                    for (int i = 0; i < e_names.Count; i++)
                    {
                        if (e_names[i] == name) exists = true;
                    }
                    if (!exists)
                    {
                        Console.WriteLine("------------------------krivi unos------------------------");
                        name = Console.ReadLine();
                    }
                }
                int c = e_names.Count;
                for (int i = 0; i < c; i++)
                {
                    if (name == e_names[i])
                    {
                        Console.WriteLine("Upisite novo ime radnika");
                        name = Console.ReadLine();
                        e_names[i] = name;
                    }
                }
            }
            else
            {
                Console.WriteLine("Upisite ime radnika kojem zelite izmjeniti godiste, a zatim novo godiste");
                for (int i = 0; i < e_names.Count; i++)
                {
                    Console.WriteLine(e_names[i]);
                }
                bool exists = false;
                name = Console.ReadLine();
                while (!exists)
                {
                    for (int i = 0; i < e_names.Count; i++)
                    {
                        if (e_names[i] == name) exists = true;
                    }
                    if (!exists)
                    {
                        Console.WriteLine("------------------------krivi unos------------------------");
                        name = Console.ReadLine();
                    }
                }
                DateTime ti;
                while (!DateTime.TryParse(Console.ReadLine(), out ti))
                {
                    Console.WriteLine("------------------------krivi unos------------------------");
                }
                int c = e_names.Count;
                for (int i = 0; i < c; i++)
                {
                    if (name == e_names[i])
                    {
                        birth[i] = ti;
                    }
                }
            }
            break;
        case 4:
            Console.WriteLine("a - Ispis svih radnika\nb - Ispis svih radnika kojima je rodendan u tekucem mjesecu");
            string act10 = Console.ReadLine();
            while(!(act10 == "a" || act10 == "b"))
            {
                Console.WriteLine("------------------------krivi unos------------------------");
                act10 = Console.ReadLine();
            }if(act10 == "a")
            {
                for (int i = 0; i < e_names.Count; i++)
                {
                    Console.WriteLine(e_names[i] + " - " + birth[i].ToString());
                }
            }
            else
            {
                var month = DateTime.Now.Month;
                for (int i = 0; i < birth.Count; i++)
                {
                    if (birth[i].Month == month)
                    {
                        Console.WriteLine(e_names[i] + " - " + birth[i].ToString());
                    }
                }
            }
            break;
        default:
            break;
    }wantMore(names, data, deadline, e_names, birth, "StoreShop", taxes_dt, taxes_p, arts, ams, howMuch);
}

//racuni
static void tax(List<string> names, List<float> data, List<DateTime> deadline, List<string> e_names, List<DateTime> birth, string k, int id, List<DateTime> taxes_dt, List<float> taxes_p, List<string> arts, List<float> ams, List<int> howMuch)
{
    Console.WriteLine("1 - Unos novog racuna\n2 - Ispis racuna");
    int act11 = -1;
    while(!(int.TryParse(Console.ReadLine(), out act11)) || !(act11 > 0 && act11 < 3)){
        Console.WriteLine("------------------------krivi unos------------------------");
    }
    List<string> t_article = new List<string>();
    List<int> t_amount = new List<int>();
    int bought = -1;
    switch (act11)
    {
        case 1:
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " - " + data[2 * i].ToString() + " - " + data[2 * i + 1].ToString() + " - " + deadline[i].ToString());
            }Console.WriteLine("Upisite ime i kolicinu proizvoda za nastavak ili upisite kljucnu rijec (StoreShop) za prekid unosa");
            string name = "";
            bool isntIn = true;
            while (isntIn)
            { 
                name = Console.ReadLine();
                for (int i = 0; i < names.Count; i++)
                {
                    if (name == names[i])
                    {
                        isntIn = false;
                    }
                }if (name == "StoreShop")
                {
                    isntIn = false;
                }if (isntIn) Console.WriteLine("------------------------krivi unos------------------------");
            }
            float price = 0;
            int hm = 0;
            bool firstart = true;
            bool quit = false;
            if (name == "StoreShop") quit = true;
            while (quit == false)
            {
                if (firstart == false) isntIn = true;
                while (isntIn)
                {
                    name = Console.ReadLine();
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (name == names[i]) isntIn = false;
                    }
                    if (name == "StoreShop") isntIn = false;
                    if (isntIn) Console.WriteLine("krivi unos");
                }
                if (name != "StoreShop")
                {
                    Console.WriteLine("Upisan je artikl " + name);
                    Console.WriteLine("Sada upisite kolicinu artikla");
                    float p = 0;
                    bool nottoomuch = true;
                    while (!int.TryParse(Console.ReadLine(), out bought) || nottoomuch)
                    {
                        Console.WriteLine("------------------------krivi unos ili neposjedujemo toliko proizvoda------------------------");
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (name == names[i])
                            {
                                p = data[2 * i];
                            }
                        }
                        if (p > 0 && p >= bought) nottoomuch = false;
                    }/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////javlja se greska di triba 2 puta upisat da bi proslo loop
                    Console.WriteLine("Pritisnite Y za potvrdu racuna ili N za ponistenje racuna");
                    string act12 = Console.ReadLine();
                    while (!(act12 == "Y" || act12 == "N"))
                    {
                        Console.WriteLine("Krivi unos");
                        act12 = Console.ReadLine();
                    }
                    if (act12 == "Y" && bought != 0)
                    {

                        t_article.Add(name);
                        t_amount.Add(bought);
                        ams.Add(bought);
                        int count = names.Count;
                        for (int i = 0; i < count; i++)
                        {
                            if (name == names[i])
                            {
                                arts.Add(name);
                                if (bought == data[2 * i])
                                {
                                    count--;
                                    names.RemoveAt(i);
                                    data.RemoveRange(2 * i, 2);
                                }
                                else
                                {
                                    data[2 * i] -= bought;
                                }
                                price += data[2 * i + 1] * bought;
                            }
                        }
                    }
                    Console.WriteLine("Nastavak racuna ili prestanak (utipkajte StoreShop)");
                }
                else
                {
                    quit = true;
                }
                hm++;
                firstart = false;
            }
            if (price != 0)
            {
                howMuch.Add(--hm);
                Console.WriteLine(" - Broj racuna - ");
                Console.WriteLine(taxes_dt.Count + 1);
                Console.WriteLine(" - Iznos racuna - ");
                Console.WriteLine(price);
                Console.WriteLine(" - Datum izdavanja racuna - ");
                Console.WriteLine(DateTime.Now);
                taxes_dt.Add(DateTime.Now);
                taxes_p.Add(price);
                id++;
            }
            break;
        case 2:
            Console.WriteLine("Ispis svih racuna");
            for (int i = 0; i < taxes_dt.Count; i++)
            {
                Console.WriteLine((i+1).ToString() + " - " + taxes_dt[i].ToString() + " - " + taxes_p[i].ToString());
            }Console.WriteLine("Zelite li ispisati neki posebni datum Y/N");
            string act13 = Console.ReadLine();
            bool correct = false;
            while (!correct)
            {
                if (act13 == "Y" || act13 == "N") correct = true;
                if (!correct)
                {
                    Console.WriteLine("------------------------krivi unos------------------------");
                    act13 = Console.ReadLine();
                }
            }
            if(act13 == "Y")
            {
                Console.WriteLine("Upisite id racuna koji vas zanima");
                int id_t;
                while (!int.TryParse(Console.ReadLine(), out id_t) || id_t > taxes_dt.Count)
                {
                    Console.WriteLine("------------------------krivi upis------------------------");
                }Console.WriteLine((id_t).ToString() + " - " + taxes_dt[id_t - 1].ToString() + " - " + taxes_p[id_t - 1].ToString());
                int until = 0;
                for (int i = 0; i < id_t-1; i++)
                {
                    until += howMuch[i];
                }
                for (int i = 0; i < arts.Count; i++)
                {
                    Console.WriteLine(arts[i]);
                    Console.WriteLine(ams[i]);
                }
                for (int i = 0; i < howMuch.Count; i++)
                {
                    Console.WriteLine(howMuch[i]);
                }
                for (int i = until; i < howMuch[id_t-1] + until; i++)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("Ime artikla - " + arts[i] + " - Kolicina artikla - " + ams[i].ToString());
                }
            }
            break;
        default:
            break;
    }wantMore(names, data, deadline, e_names, birth, "StoreShop", taxes_dt, taxes_p, arts, ams, howMuch);
}
//statistika
static void statistic(List<string> names, List<float> data, List<DateTime> deadline, List<DateTime> birth, List<string> e_names, List<DateTime> taxes_dt, List<float> taxes_p, List<string> arts, List<float> ams, List<int> howMuch)
{
    Console.WriteLine("Upisite sifru za nastavak (StoreShop)");
    Console.WriteLine("1 - Ukupan broj artikala\n2 - Vrijednost artikala koji nisu jos prodani\n3 - Vrijednost svih artikala koji su prodani\n4 - Financijsko stanje");
    int act14 = -1;
    while(int.TryParse(Console.ReadLine(), out act14) && !(act14 > 0 && act14 < 5))
    {
        Console.WriteLine("Krivi unos");
    }
    switch (act14)
    {
        case 1:
            float s = 0;
            for (int i = 0; i < names.Count; i++)
            {
                s += data[2*i];
            }Console.WriteLine("U trgovini se nalaze " + s.ToString() + " artikla");
            break;
        case 2:
            float p = 0;
            for (int i = 0; i < names.Count; i++)
            {
                p += data[2 * i + 1] * data[2 * i];
            }
            Console.WriteLine("Ukupna vrijednost artikala u trgovini je " + p.ToString());
            break;
        case 3:
            float p1 = 0;
            for (int i = 0; i < taxes_dt.Count; i++)
            {
                p1 += taxes_p[i];
            }Console.WriteLine("Ukupna vrijednost prodanih artikala iznosi " + p1.ToString());
            break;
        case 4:
            float rent = 807.45f;
            float salary = 1100.7f;
            float other = 120.76f;
            Console.WriteLine("Molim unesite datum");
            int month = -1;
            while(!int.TryParse(Console.ReadLine(), out month) || !(month > 0 && month < 13))
            {
                Console.WriteLine("Krivi unos");
            }
            Console.WriteLine("Molim unesite godinu");
            int year = -1;
            while (!int.TryParse(Console.ReadLine(), out year) || year < 0)
            {
                Console.WriteLine("Krivi unos");
            }
            float pay = 0;
            for (int i = 0; i < taxes_dt.Count; i++)
            {
                if(year == taxes_dt[i].Year && month == taxes_dt[i].Month)
                {
                    pay += taxes_p[i];
                }
            }pay /= 3;
            pay = pay - rent - salary * e_names.Count - other;
            Console.WriteLine("Ukupni prihodi toga mjeseca: " + pay.ToString());
            break;
        default:
            break;
    }wantMore(names, data, deadline, e_names, birth, "StoreShop", taxes_dt, taxes_p, arts, ams, howMuch);
}

static void output(List<string> names, List<float> data, List<DateTime> deadline, string s, List<string> arts, List<float> ams)
{
    List<float> popularity = new List<float>();
    for (int i = 0; i < names.Count; i++)
    {
        popularity.Add(0);
    }
    for(int i = 0; i < arts.Count; i++)
    {
        for(int j = 0; j < names.Count; j++)
        {
            if (arts[i] == names[j]) popularity[j] += ams[i];
        }
    }
    switch (s)
    {
        case "a":
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " (" + data[2 * i].ToString() + ") - " + data[2 * i + 1].ToString() + " - ");
                Console.WriteLine((deadline[i] - DateTime.Now).TotalDays);
            }
            break;
        case "b":
            string temp_s;
            float temp_f;
            DateTime temp_dt;
            for (int i = 0; i < names.Count - 1; i++)
            {
                for(int j = i; j < names.Count; j++)
                {
                    if (names[i][0] > names[j][0])
                    {
                        temp_s = names[i];
                        names[i] = names[j];
                        names[j] = temp_s;
                        temp_f = data[2 * i];
                        data[2 * i] = data[2 * j];
                        data[2 * j] = temp_f;
                        temp_f = data[2 * i + 1];
                        data[2 * i + 1] = data[2 * j + 1];
                        data[2 * j + 1] = temp_f;
                        temp_dt = deadline[i];
                        deadline[i] = deadline[j];
                        deadline[j] = temp_dt;
                    }
                }
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " (" + data[2 * i].ToString() + ") - " + data[2 * i + 1].ToString() + " - ");
                Console.WriteLine((deadline[i] - DateTime.Now).TotalDays);
            }
            break;
        case "c":
            for (int i = 0; i < names.Count - 1; i++)
            {
                for (int j = i; j < names.Count; j++)
                {
                    if (deadline[i] < deadline[j])
                    {
                        temp_s = names[i];
                        names[i] = names[j];
                        names[j] = temp_s;
                        temp_f = data[2 * i];
                        data[2 * i] = data[2 * j];
                        data[2 * j] = temp_f;
                        temp_f = data[2 * i + 1];
                        data[2 * i + 1] = data[2 * j + 1];
                        data[2 * j + 1] = temp_f;
                        temp_dt = deadline[i];
                        deadline[i] = deadline[j];
                        deadline[j] = temp_dt;
                    }
                }
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " (" + data[2 * i].ToString() + ") - " + data[2 * i + 1].ToString() + " - ");
                Console.WriteLine((deadline[i] - DateTime.Now).TotalDays);
            }
            break;
        case "d":
            for (int i = 0; i < names.Count - 1; i++)
            {
                for (int j = i; j < names.Count; j++)
                {
                    if (deadline[i] > deadline[j])
                    {
                        temp_s = names[i];
                        names[i] = names[j];
                        names[j] = temp_s;
                        temp_f = data[2 * i];
                        data[2 * i] = data[2 * j];
                        data[2 * j] = temp_f;
                        temp_f = data[2 * i + 1];
                        data[2 * i + 1] = data[2 * j + 1];
                        data[2 * j + 1] = temp_f;
                        temp_dt = deadline[i];
                        deadline[i] = deadline[j];
                        deadline[j] = temp_dt;
                    }
                }
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " (" + data[2 * i].ToString() + ") - " + data[2 * i + 1].ToString() + " - ");
                Console.WriteLine((deadline[i] - DateTime.Now).TotalDays);
            }
            break;
        case "e":
            for (int i = 0; i < names.Count - 2; i++)
            {
                for (int j = i; j < names.Count; j++)
                {
                    if (data[2*i] < data[2*j])
                    {
                        temp_s = names[i];
                        names[i] = names[j];
                        names[j] = temp_s;
                        temp_f = data[2 * i];
                        data[2 * i] = data[2 * j];
                        data[2 * j] = temp_f;
                        temp_f = data[2 * i + 1];
                        data[2 * i + 1] = data[2 * j + 1];
                        data[2 * j + 1] = temp_f;
                        temp_dt = deadline[i];
                        deadline[i] = deadline[j];
                        deadline[j] = temp_dt;
                    }
                }
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i] + " (" + data[2 * i].ToString() + ") - " + data[2 * i + 1].ToString() + " - ");
                Console.WriteLine((deadline[i] - DateTime.Now).TotalDays);
            }
            break;
        case "f":
            string most = "";
            float max = 0;
            for(int i = 0; i < popularity.Count; i++)
            {
                if (popularity[i] > max)
                {
                    max = popularity[i];
                    most = names[i];
                }
            }
            Console.WriteLine("Najprodavaniji artikl je " + most);
            break;
        case "g":
            string least = "";
            float min = float.MaxValue;
            for (int i = 0; i < popularity.Count; i++)
            {
                if (popularity[i] < min)
                {
                    min = popularity[i];
                    least = names[i];
                }
            }
            Console.WriteLine("Najmanje prodavan artikl je " + least);
            break;
        default:
            break;
    }
}