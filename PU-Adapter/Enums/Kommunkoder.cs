using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kentor.PU_Adapter.Enums
{
    public enum Kommunkoder
    {
        // 01 Stockholms län
        [Description("Upplands Väsby")]
        Upplands_Väsby = 0114,
        [Description("Vallentuna")]
        Vallentuna = 0115,
        [Description("Österåker")]
        Österåker = 0117,
        [Description("Värmdö")]
        Värmdö = 0120,
        [Description("Järfälla")]
        Järfälla = 0123,
        [Description("Ekerö")]
        Ekerö = 0125,
        [Description("Huddinge")]
        Huddinge = 0126,
        [Description("Botkyrka")]
        Botkyrka = 0127,
        [Description("Salem")]
        Salem = 0128,
        [Description("Haninge")]
        Haninge = 0136,
        [Description("Tyresö")]
        Tyresö = 0138,
        [Description("Upplands-Bro")]
        Upplands_Bro = 0139,
        [Description("Nykvarn")]
        Nykvarn = 0140,
        [Description("Täby")]
        Täby = 0160,
        [Description("Danderyd")]
        Danderyd = 0162,
        [Description("Sollentuna")]
        Sollentuna = 0163,
        [Description("Stockholm")]
        Stockholm = 0180,
        [Description("Södertälje")]
        Södertälje = 0181,
        [Description("Nacka")]
        Nacka = 0182,
        [Description("Sundbyberg")]
        Sundbyberg = 0183,
        [Description("Solna")]
        Solna = 0184,
        [Description("Lidingö")]
        Lidingö = 0186,
        [Description("Vaxholm")]
        Vaxholm = 0187,
        [Description("Norrtälje")]
        Norrtälje = 0188,
        [Description("Sigtuna")]
        Sigtuna = 0191,
        [Description("Nynäshamn")]
        Nynäshamn = 0192,
        // 03 Uppsala län
        [Description("Håbo")]
        Håbo = 0305,
        [Description("Älvkarleby")]
        Älvkarleby = 0319,
        [Description("Knivsta")]
        Knivsta = 0330,
        [Description("Heby")]
        Heby = 0331,
        [Description("Tierp")]
        Tierp = 0360,
        [Description("Uppsala")]
        Uppsala = 0380,
        [Description("Enköping")]
        Enköping = 0381,
        [Description("Östhammar")]
        Östhammar = 0382,
        // 04 Södermanlands län
        [Description("Vingåker")]
        Vingåker = 0428,
        [Description("Gnesta")]
        Gnesta = 0461,
        [Description("Nyköping")]
        Nyköping = 0480,
        [Description("Oxelösund")]
        Oxelösund = 0481,
        [Description("Flen")]
        Flen = 0482,
        [Description("Katrineholm")]
        Katrineholm = 0483,
        [Description("Eskilstuna")]
        Eskilstuna = 0484,
        [Description("Strängnäs")]
        Strängnäs = 0486,
        [Description("Trosa")]
        Trosa = 0488,
        // 05 Östergötlands län
        [Description("Ödeshög")]
        Ödeshög = 0509,
        [Description("Ydre")]
        Ydre = 0512,
        [Description("Kinda")]
        Kinda = 0513,
        [Description("Boxholm")]
        Boxholm = 0560,
        [Description("Åtvidaberg")]
        Åtvidaberg = 0561,
        [Description("Finspång")]
        Finspång = 0562,
        [Description("Valdemarsvik")]
        Valdemarsvik = 0563,
        [Description("Linköping")]
        Linköping = 0580,
        [Description("Norrköping")]
        Norrköping = 0581,
        [Description("Söderköping")]
        Söderköping = 0582,
        [Description("Motala")]
        Motala = 0583,
        [Description("Vadstena")]
        Vadstena = 0584,
        [Description("Mjölby")]
        Mjölby = 0586,
        // 06 Jönköpings län
        [Description("Aneby")]
        Aneby = 0604,
        [Description("Gnosjö")]
        Gnosjö = 0617,
        [Description("Mullsjö")]
        Mullsjö = 0642,
        [Description("Habo")]
        Habo = 0643,
        [Description("Gislaved")]
        Gislaved = 0662,
        [Description("Vaggeryd")]
        Vaggeryd = 0665,
        [Description("Jönköping")]
        Jönköping = 0680,
        [Description("Nässjö")]
        Nässjö = 0682,
        [Description("Värnamo")]
        Värnamo = 0683,
        [Description("Sävsjö")]
        Sävsjö = 0684,
        [Description("Vetlanda")]
        Vetlanda = 0685,
        [Description("Eksjö")]
        Eksjö = 0686,
        [Description("Tranås")]
        Tranås = 0687,
        // 07 Kronobergs län
        [Description("Uppvidinge")]
        Uppvidinge = 0760,
        [Description("Lessebo")]
        Lessebo = 0761,
        [Description("Tingsryd")]
        Tingsryd = 0763,
        [Description("Alvesta")]
        Alvesta = 0764,
        [Description("Älmhult")]
        Älmhult = 0765,
        [Description("Markaryd")]
        Markaryd = 0767,
        [Description("Växjö")]
        Växjö = 0780,
        [Description("Ljungby")]
        Ljungby = 0781,
        // 08 Kalmar län
        [Description("Högsby")]
        Högsby = 0821,
        [Description("Torsås")]
        Torsås = 0834,
        [Description("Mörbylånga")]
        Mörbylånga = 0840,
        [Description("Hultsfred")]
        Hultsfred = 0860,
        [Description("Mönsterås")]
        Mönsterås = 0861,
        [Description("Emmaboda")]
        Emmaboda = 0862,
        [Description("Kalmar")]
        Kalmar = 0880,
        [Description("Nybro")]
        Nybro = 0881,
        [Description("Oskarshamn")]
        Oskarshamn = 0882,
        [Description("Västervik")]
        Västervik = 0883,
        [Description("Vimmerby")]
        Vimmerby = 0884,
        [Description("Borgholm")]
        Borgholm = 0885,
        // 09 Gotlands län
        [Description("Gotland")]
        Gotland = 0980,
        // 10 Blekinge län
        [Description("Olofström")]
        Olofström = 1060,
        [Description("Karlskrona")]
        Karlskrona = 1080,
        [Description("Ronneby")]
        Ronneby = 1081,
        [Description("Karlshamn")]
        Karlshamn = 1082,
        [Description("Sölvesborg")]
        Sölvesborg = 1083,
        // 12 Skåne län
        [Description("Svalöv")]
        Svalöv = 1214,
        [Description("Staffanstorp")]
        Staffanstorp = 1230,
        [Description("Burlöv")]
        Burlöv = 1231,
        [Description("Vellinge")]
        Vellinge = 1233,
        [Description("Östra Göinge")]
        Östra_Göinge = 1256,
        [Description("Örkelljunga")]
        Örkelljunga = 1257,
        [Description("Bjuv")]
        Bjuv = 1260,
        [Description("Kävlinge")]
        Kävlinge = 1261,
        [Description("Lomma")]
        Lomma = 1262,
        [Description("Svedala")]
        Svedala = 1263,
        [Description("Skurup")]
        Skurup = 1264,
        [Description("Sjöbo")]
        Sjöbo = 1265,
        [Description("Hörby")]
        Hörby = 1266,
        [Description("Höör")]
        Höör = 1267,
        [Description("Tomelilla")]
        Tomelilla = 1270,
        [Description("Bromölla")]
        Bromölla = 1272,
        [Description("Osby")]
        Osby = 1273,
        [Description("Perstorp")]
        Perstorp = 1275,
        [Description("Klippan")]
        Klippan = 1276,
        [Description("Åstorp")]
        Åstorp = 1277,
        [Description("Båstad")]
        Båstad = 1278,
        [Description("Malmö")]
        Malmö = 1280,
        [Description("Lund")]
        Lund = 1281,
        [Description("Landskrona")]
        Landskrona = 1282,
        [Description("Helsingborg")]
        Helsingborg = 1283,
        [Description("Höganäs")]
        Höganäs = 1284,
        [Description("Eslöv")]
        Eslöv = 1285,
        [Description("Ystad")]
        Ystad = 1286,
        [Description("Trelleborg")]
        Trelleborg = 1287,
        [Description("Kristianstad")]
        Kristianstad = 1290,
        [Description("Simrishamn")]
        Simrishamn = 1291,
        [Description("Ängelholm")]
        Ängelholm = 1292,
        [Description("Hässleholm")]
        Hässleholm = 1293,
        // 13 Hallands län
        [Description("Hylte")]
        Hylte = 1315,
        [Description("Halmstad")]
        Halmstad = 1380,
        [Description("Laholm")]
        Laholm = 1381,
        [Description("Falkenberg")]
        Falkenberg = 1382,
        [Description("Varberg")]
        Varberg = 1383,
        [Description("Kungsbacka")]
        Kungsbacka = 1384,
        // 14 Västra Götalands län
        [Description("Härryda")]
        Härryda = 1401,
        [Description("Partille")]
        Partille = 1402,
        [Description("Öckerö")]
        Öckerö = 1407,
        [Description("Stenungsund")]
        Stenungsund = 1415,
        [Description("Tjörn")]
        Tjörn = 1419,
        [Description("Orust")]
        Orust = 1421,
        [Description("Sotenäs")]
        Sotenäs = 1427,
        [Description("Munkedal")]
        Munkedal = 1430,
        [Description("Tanum")]
        Tanum = 1435,
        [Description("Dals-Ed")]
        Dals_Ed = 1438,
        [Description("Färgelanda")]
        Färgelanda = 1439,
        [Description("Ale")]
        Ale = 1440,
        [Description("Lerum")]
        Lerum = 1441,
        [Description("Vårgårda")]
        Vårgårda = 1442,
        [Description("Bollebygd")]
        Bollebygd = 1443,
        [Description("Grästorp")]
        Grästorp = 1444,
        [Description("Essunga")]
        Essunga = 1445,
        [Description("Karlsborg")]
        Karlsborg = 1446,
        [Description("Gullspång")]
        Gullspång = 1447,
        [Description("Tranemo")]
        Tranemo = 1452,
        [Description("Bengtsfors")]
        Bengtsfors = 1460,
        [Description("Mellerud")]
        Mellerud = 1461,
        [Description("Lilla Edet")]
        Lilla_Edet = 1462,
        [Description("Mark")]
        Mark = 1463,
        [Description("Svenljunga")]
        Svenljunga = 1465,
        [Description("Herrljunga")]
        Herrljunga = 1466,
        [Description("Vara")]
        Vara = 1470,
        [Description("Götene")]
        Götene = 1471,
        [Description("Tibro")]
        Tibro = 1472,
        [Description("Töreboda")]
        Töreboda = 1473,
        [Description("Göteborg")]
        Göteborg = 1480,
        [Description("Mölndal")]
        Mölndal = 1481,
        [Description("Kungälv")]
        Kungälv = 1482,
        [Description("Lysekil")]
        Lysekil = 1484,
        [Description("Uddevalla")]
        Uddevalla = 1485,
        [Description("Strömstad")]
        Strömstad = 1486,
        [Description("Vänersborg")]
        Vänersborg = 1487,
        [Description("Trollhättan")]
        Trollhättan = 1488,
        [Description("Alingsås")]
        Alingsås = 1489,
        [Description("Borås")]
        Borås = 1490,
        [Description("Ulricehamn")]
        Ulricehamn = 1491,
        [Description("Åmål")]
        Åmål = 1492,
        [Description("Mariestad")]
        Mariestad = 1493,
        [Description("Lidköping")]
        Lidköping = 1494,
        [Description("Skara")]
        Skara = 1495,
        [Description("Skövde")]
        Skövde = 1496,
        [Description("Hjo")]
        Hjo = 1497,
        [Description("Tidaholm")]
        Tidaholm = 1498,
        [Description("Falköping")]
        Falköping = 1499,
        // 17 Värmlands län
        [Description("Kil")]
        Kil = 1715,
        [Description("Eda")]
        Eda = 1730,
        [Description("Torsby")]
        Torsby = 1737,
        [Description("Storfors")]
        Storfors = 1760,
        [Description("Hammarö")]
        Hammarö = 1761,
        [Description("Munkfors")]
        Munkfors = 1762,
        [Description("Forshaga")]
        Forshaga = 1763,
        [Description("Grums")]
        Grums = 1764,
        [Description("Årjäng")]
        Årjäng = 1765,
        [Description("Sunne")]
        Sunne = 1766,
        [Description("Karlstad")]
        Karlstad = 1780,
        [Description("Kristinehamn")]
        Kristinehamn = 1781,
        [Description("Filipstad")]
        Filipstad = 1782,
        [Description("Hagfors")]
        Hagfors = 1783,
        [Description("Arvika")]
        Arvika = 1784,
        [Description("Säffle")]
        Säffle = 1785,
        // 18 Örebro län
        [Description("Lekeberg")]
        Lekeberg = 1814,
        [Description("Laxå")]
        Laxå = 1860,
        [Description("Hallsberg")]
        Hallsberg = 1861,
        [Description("Degerfors")]
        Degerfors = 1862,
        [Description("Hällefors")]
        Hällefors = 1863,
        [Description("Ljusnarsberg")]
        Ljusnarsberg = 1864,
        [Description("Örebro")]
        Örebro = 1880,
        [Description("Kumla")]
        Kumla = 1881,
        [Description("Askersund")]
        Askersund = 1882,
        [Description("Karlskoga")]
        Karlskoga = 1883,
        [Description("Nora")]
        Nora = 1884,
        [Description("Lindesberg")]
        Lindesberg = 1885,
        // 19 Västmanlands län
        [Description("Skinnskatteberg")]
        Skinnskatteberg = 1904,
        [Description("Surahammar")]
        Surahammar = 1907,
        [Description("Kungsör")]
        Kungsör = 1960,
        [Description("Hallstahammar")]
        Hallstahammar = 1961,
        [Description("Norberg")]
        Norberg = 1962,
        [Description("Västerås")]
        Västerås = 1980,
        [Description("Sala")]
        Sala = 1981,
        [Description("Fagersta")]
        Fagersta = 1982,
        [Description("Köping")]
        Köping = 1983,
        [Description("Arboga")]
        Arboga = 1984,
        // 20 Dalarnas län
        [Description("Vansbro")]
        Vansbro = 2021,
        [Description("Malung-Sälen")]
        Malung_Sälen = 2023,
        [Description("Gagnef")]
        Gagnef = 2026,
        [Description("Leksand")]
        Leksand = 2029,
        [Description("Rättvik")]
        Rättvik = 2031,
        [Description("Orsa")]
        Orsa = 2034,
        [Description("Älvdalen")]
        Älvdalen = 2039,
        [Description("Smedjebacken")]
        Smedjebacken = 2061,
        [Description("Mora")]
        Mora = 2062,
        [Description("Falun")]
        Falun = 2080,
        [Description("Borlänge")]
        Borlänge = 2081,
        [Description("Säter")]
        Säter = 2082,
        [Description("Hedemora")]
        Hedemora = 2083,
        [Description("Avesta")]
        Avesta = 2084,
        [Description("Ludvika")]
        Ludvika = 2085,
        // 21 Gävleborgs län
        [Description("Ockelbo")]
        Ockelbo = 2101,
        [Description("Hofors")]
        Hofors = 2104,
        [Description("Ovanåker")]
        Ovanåker = 2121,
        [Description("Nordanstig")]
        Nordanstig = 2132,
        [Description("Ljusdal")]
        Ljusdal = 2161,
        [Description("Gävle")]
        Gävle = 2180,
        [Description("Sandviken")]
        Sandviken = 2181,
        [Description("Söderhamn")]
        Söderhamn = 2182,
        [Description("Bollnäs")]
        Bollnäs = 2183,
        [Description("Hudiksvall")]
        Hudiksvall = 2184,
        // 22 Västernorrlands län
        [Description("Ånge")]
        Ånge = 2260,
        [Description("Timrå")]
        Timrå = 2262,
        [Description("Härnösand")]
        Härnösand = 2280,
        [Description("Sundsvall")]
        Sundsvall = 2281,
        [Description("Kramfors")]
        Kramfors = 2282,
        [Description("Sollefteå")]
        Sollefteå = 2283,
        [Description("Örnsköldsvik")]
        Örnsköldsvik = 2284,
        // 23 Jämtlands län
        [Description("Ragunda")]
        Ragunda = 2303,
        [Description("Bräcke")]
        Bräcke = 2305,
        [Description("Krokom")]
        Krokom = 2309,
        [Description("Strömsund")]
        Strömsund = 2313,
        [Description("Åre")]
        Åre = 2321,
        [Description("Berg")]
        Berg = 2326,
        [Description("Härjedalen")]
        Härjedalen = 2361,
        [Description("Östersund")]
        Östersund = 2380,
        // 24 Västerbottens län
        [Description("Nordmaling")]
        Nordmaling = 2401,
        [Description("Bjurholm")]
        Bjurholm = 2403,
        [Description("Vindeln")]
        Vindeln = 2404,
        [Description("Robertsfors")]
        Robertsfors = 2409,
        [Description("Norsjö")]
        Norsjö = 2417,
        [Description("Malå")]
        Malå = 2418,
        [Description("Storuman")]
        Storuman = 2421,
        [Description("Sorsele")]
        Sorsele = 2422,
        [Description("Dorotea")]
        Dorotea = 2425,
        [Description("Vännäs")]
        Vännäs = 2460,
        [Description("Vilhelmina")]
        Vilhelmina = 2462,
        [Description("Åsele")]
        Åsele = 2463,
        [Description("Umeå")]
        Umeå = 2480,
        [Description("Lycksele")]
        Lycksele = 2481,
        [Description("Skellefteå")]
        Skellefteå = 2482,
        // 25 Norrbottens län
        [Description("Arvidsjaur")]
        Arvidsjaur = 2505,
        [Description("Arjeplog")]
        Arjeplog = 2506,
        [Description("Jokkmokk")]
        Jokkmokk = 2510,
        [Description("Överkalix")]
        Överkalix = 2513,
        [Description("Kalix")]
        Kalix = 2514,
        [Description("Övertorneå")]
        Övertorneå = 2518,
        [Description("Pajala")]
        Pajala = 2521,
        [Description("Gällivare")]
        Gällivare = 2523,
        [Description("Älvsbyn")]
        Älvsbyn = 2560,
        [Description("Luleå")]
        Luleå = 2580,
        [Description("Piteå")]
        Piteå = 2581,
        [Description("Boden")]
        Boden = 2582,
        [Description("Haparanda")]
        Haparanda = 2583,
        [Description("Kiruna")]
        Kiruna = 2584,
    }
}
