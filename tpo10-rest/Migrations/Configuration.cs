namespace tpo10_rest.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
#if false
            #region Roles
            var roleAdministrator = new IdentityRole { Name = nameof(Administrator) };
            var roleDoctor = new IdentityRole { Name = nameof(Doctor) };
            var roleNurse = new IdentityRole { Name = nameof(Nurse) };
            var rolePatient = new IdentityRole { Name = nameof(Patient) };
            #region Role Inserts
            context.Roles.AddOrUpdate(
                r => r.Name,
                roleAdministrator,
                roleDoctor,
                roleNurse,
                rolePatient
            );
            #endregion
            #endregion

            #region Posts
            var post1000 = new Post { PostNumber = 1000, PostName = "Ljubljana" };
            var post1001 = new Post { PostNumber = 1001, PostName = "Ljubljana" };
            var post1002 = new Post { PostNumber = 1002, PostName = "Ljubljana - poštni center" };
            var post1004 = new Post { PostNumber = 1004, PostName = "Ljubljana - carinska pošta" };
            var post1210 = new Post { PostNumber = 1210, PostName = "Ljubljana - Šentvid" };
            var post1211 = new Post { PostNumber = 1211, PostName = "Ljubljana - Šmartno" };
            var post1215 = new Post { PostNumber = 1215, PostName = "Medvode" };
            var post1216 = new Post { PostNumber = 1216, PostName = "Smlednik" };
            var post1217 = new Post { PostNumber = 1217, PostName = "Vodice" };
            var post1218 = new Post { PostNumber = 1218, PostName = "Komenda" };
            var post1219 = new Post { PostNumber = 1219, PostName = "Laze v Tuhinju" };
            var post1221 = new Post { PostNumber = 1221, PostName = "Motnik" };
            var post1222 = new Post { PostNumber = 1222, PostName = "Trojane" };
            var post1223 = new Post { PostNumber = 1223, PostName = "Blagovica" };
            var post1225 = new Post { PostNumber = 1225, PostName = "Lukovica" };
            var post1230 = new Post { PostNumber = 1230, PostName = "Domžale" };
            var post1231 = new Post { PostNumber = 1231, PostName = "Ljubljana -črnuče" };
            var post1233 = new Post { PostNumber = 1233, PostName = "Dob" };
            var post1234 = new Post { PostNumber = 1234, PostName = "Mengeš" };
            var post1235 = new Post { PostNumber = 1235, PostName = "Radomlje" };
            var post1236 = new Post { PostNumber = 1236, PostName = "Trzin" };
            var post1241 = new Post { PostNumber = 1241, PostName = "Kamnik" };
            var post1242 = new Post { PostNumber = 1242, PostName = "Stahovica" };
            var post1251 = new Post { PostNumber = 1251, PostName = "Moravče" };
            var post1252 = new Post { PostNumber = 1252, PostName = "Vače" };
            var post1260 = new Post { PostNumber = 1260, PostName = "Ljubljana - Polje" };
            var post1261 = new Post { PostNumber = 1261, PostName = "Ljubljana - Dobrunje" };
            var post1262 = new Post { PostNumber = 1262, PostName = "Dol pri Ljubljani" };
            var post1270 = new Post { PostNumber = 1270, PostName = "Litija" };
            var post1272 = new Post { PostNumber = 1272, PostName = "Polšnik" };
            var post1273 = new Post { PostNumber = 1273, PostName = "Dole pri Litiji" };
            var post1274 = new Post { PostNumber = 1274, PostName = "Gabrovka" };
            var post1275 = new Post { PostNumber = 1275, PostName = "Šmartno pri Litiji" };
            var post1276 = new Post { PostNumber = 1276, PostName = "Primskovo" };
            var post1281 = new Post { PostNumber = 1281, PostName = "Kresnice" };
            var post1282 = new Post { PostNumber = 1282, PostName = "Sava" };
            var post1290 = new Post { PostNumber = 1290, PostName = "Grosuplje" };
            var post1291 = new Post { PostNumber = 1291, PostName = "Škofljica" };
            var post1292 = new Post { PostNumber = 1292, PostName = "Ig" };
            var post1293 = new Post { PostNumber = 1293, PostName = "Šmarje - Sap" };
            var post1294 = new Post { PostNumber = 1294, PostName = "Višnja Gora" };
            var post1295 = new Post { PostNumber = 1295, PostName = "Ivančna Gorica" };
            var post1296 = new Post { PostNumber = 1296, PostName = "Šentvid pri Stični" };
            var post1301 = new Post { PostNumber = 1301, PostName = "Krka" };
            var post1303 = new Post { PostNumber = 1303, PostName = "Zagradec" };
            var post1310 = new Post { PostNumber = 1310, PostName = "Ribnica" };
            var post1311 = new Post { PostNumber = 1311, PostName = "Turjak" };
            var post1312 = new Post { PostNumber = 1312, PostName = "Videm - Dobrepolje" };
            var post1313 = new Post { PostNumber = 1313, PostName = "Struge" };
            var post1314 = new Post { PostNumber = 1314, PostName = "Rob" };
            var post1315 = new Post { PostNumber = 1315, PostName = "Velike Lašče" };
            var post1316 = new Post { PostNumber = 1316, PostName = "Ortnek" };
            var post1317 = new Post { PostNumber = 1317, PostName = "Sodražica" };
            var post1318 = new Post { PostNumber = 1318, PostName = "Loški Potok" };
            var post1319 = new Post { PostNumber = 1319, PostName = "Draga" };
            var post1330 = new Post { PostNumber = 1330, PostName = "Kočevje" };
            var post1331 = new Post { PostNumber = 1331, PostName = "Dolenja vas" };
            var post1332 = new Post { PostNumber = 1332, PostName = "Stara Cerkev" };
            var post1336 = new Post { PostNumber = 1336, PostName = "Kostel" };
            var post1337 = new Post { PostNumber = 1337, PostName = "Osilnica" };
            var post1338 = new Post { PostNumber = 1338, PostName = "Kočevska Reka" };
            var post1351 = new Post { PostNumber = 1351, PostName = "Brezovica pri Ljubljani" };
            var post1352 = new Post { PostNumber = 1352, PostName = "Preserje" };
            var post1353 = new Post { PostNumber = 1353, PostName = "Borovnica" };
            var post1354 = new Post { PostNumber = 1354, PostName = "Horjul" };
            var post1355 = new Post { PostNumber = 1355, PostName = "Polhov Gradec" };
            var post1356 = new Post { PostNumber = 1356, PostName = "Dobrova" };
            var post1357 = new Post { PostNumber = 1357, PostName = "Notranje Gorice" };
            var post1358 = new Post { PostNumber = 1358, PostName = "Log pri Brezovici" };
            var post1360 = new Post { PostNumber = 1360, PostName = "Vrhnika" };
            var post1370 = new Post { PostNumber = 1370, PostName = "Logatec" };
            var post1372 = new Post { PostNumber = 1372, PostName = "Hotedršica" };
            var post1373 = new Post { PostNumber = 1373, PostName = "Rovte" };
            var post1380 = new Post { PostNumber = 1380, PostName = "Cerknica" };
            var post1381 = new Post { PostNumber = 1381, PostName = "Rakek" };
            var post1382 = new Post { PostNumber = 1382, PostName = "Begunje pri Cerknici" };
            var post1384 = new Post { PostNumber = 1384, PostName = "Grahovo" };
            var post1385 = new Post { PostNumber = 1385, PostName = "Nova vas" };
            var post1386 = new Post { PostNumber = 1386, PostName = "Stari trg pri Ložu" };
            var post1410 = new Post { PostNumber = 1410, PostName = "Zagorje ob Savi" };
            var post1411 = new Post { PostNumber = 1411, PostName = "Izlake" };
            var post1412 = new Post { PostNumber = 1412, PostName = "Kisovec" };
            var post1413 = new Post { PostNumber = 1413, PostName = "čemšenik" };
            var post1414 = new Post { PostNumber = 1414, PostName = "Podkum" };
            var post1420 = new Post { PostNumber = 1420, PostName = "Trbovlje" };
            var post1423 = new Post { PostNumber = 1423, PostName = "Dobovec" };
            var post1430 = new Post { PostNumber = 1430, PostName = "Hrastnik" };
            var post1431 = new Post { PostNumber = 1431, PostName = "Dol pri Hrastniku" };
            var post1432 = new Post { PostNumber = 1432, PostName = "Zidani Most" };
            var post1433 = new Post { PostNumber = 1433, PostName = "Radeče" };
            var post1434 = new Post { PostNumber = 1434, PostName = "Loka pri Zidanem Mostu" };
            var post1501 = new Post { PostNumber = 1501, PostName = "Ljubljana Ministrstvo za notranje zadeve" };
            var post1502 = new Post { PostNumber = 1502, PostName = "Ljubljana Ministrstvo za finance" };
            var post1503 = new Post { PostNumber = 1503, PostName = "Ljubljana Okrožno sodišče v Ljubljani" };
            var post1504 = new Post { PostNumber = 1504, PostName = "Ljubljana Gospodarska zbornica Slovenije" };
            var post1505 = new Post { PostNumber = 1505, PostName = "Ljubljana Banka Slovenije" };
            var post1506 = new Post { PostNumber = 1506, PostName = "Ljubljana Slovenske železnice" };
            var post1507 = new Post { PostNumber = 1507, PostName = "Ljubljana Zavod za zdrav.zav.Slov." };
            var post1509 = new Post { PostNumber = 1509, PostName = "Ljubljana Delo" };
            var post1510 = new Post { PostNumber = 1510, PostName = "Ljubljana Dnevnik" };
            var post1511 = new Post { PostNumber = 1511, PostName = "Ljubljana Slovenijales" };
            var post1512 = new Post { PostNumber = 1512, PostName = "Ljubljana Cankarjeva založba" };
            var post1513 = new Post { PostNumber = 1513, PostName = "Ljubljana SKB banka" };
            var post1514 = new Post { PostNumber = 1514, PostName = "Ljubljana Kompas" };
            var post1516 = new Post { PostNumber = 1516, PostName = "Ljubljana Elektro Ljubljana" };
            var post1517 = new Post { PostNumber = 1517, PostName = "Ljubljana Abanka Vipa" };
            var post1518 = new Post { PostNumber = 1518, PostName = "Ljubljana Zavod za pokoj. in inval.zav.Slov." };
            var post1519 = new Post { PostNumber = 1519, PostName = "Ljubljana SPL Ljubljana" };
            var post1520 = new Post { PostNumber = 1520, PostName = "Ljubljana Nova Ljubljanska banka" };
            var post1521 = new Post { PostNumber = 1521, PostName = "Ljubljana Iskra invest" };
            var post1522 = new Post { PostNumber = 1522, PostName = "Ljubljana Chemo" };
            var post1523 = new Post { PostNumber = 1523, PostName = "Ljubljana Carinska uprava Republike Slovenije" };
            var post1524 = new Post { PostNumber = 1524, PostName = "Ljubljana Carinarnica Ljubljana" };
            var post1525 = new Post { PostNumber = 1525, PostName = "Ljubljana Klinični center Ljubljana" };
            var post1526 = new Post { PostNumber = 1526, PostName = "Ljubljana Lek" };
            var post1527 = new Post { PostNumber = 1527, PostName = "Ljubljana Petrol" };
            var post1528 = new Post { PostNumber = 1528, PostName = "Ljubljana Emona" };
            var post1529 = new Post { PostNumber = 1529, PostName = "Ljubljana Žito" };
            var post1532 = new Post { PostNumber = 1532, PostName = "Ljubljana Salamonov oglasnik" };
            var post1533 = new Post { PostNumber = 1533, PostName = "Ljubljana BTC" };
            var post1534 = new Post { PostNumber = 1534, PostName = "Ljubljana Okrajno sodišče v Ljubljani" };
            var post1535 = new Post { PostNumber = 1535, PostName = "Ljubljana Ministrstvo za promet" };
            var post1536 = new Post { PostNumber = 1536, PostName = "Ljubljana Mladinska knjiga Založba" };
            var post1537 = new Post { PostNumber = 1537, PostName = "Ljubljana Mobitel, d.d." };
            var post1538 = new Post { PostNumber = 1538, PostName = "Ljubljana DZS" };
            var post1540 = new Post { PostNumber = 1540, PostName = "Ljubljana EPPS, Elektron.pismo Pošte Slov." };
            var post1542 = new Post { PostNumber = 1542, PostName = "Ljubljana KDD - Centralna klirinško depotna družba" };
            var post1543 = new Post { PostNumber = 1543, PostName = "Ljubljana Športna loterija" };
            var post1544 = new Post { PostNumber = 1544, PostName = "Ljubljana Kolinska" };
            var post1545 = new Post { PostNumber = 1545, PostName = "Ljubljana Kanal A" };
            var post1546 = new Post { PostNumber = 1546, PostName = "Ljubljana Telekom Slovenije" };
            var post1547 = new Post { PostNumber = 1547, PostName = "Ljubljana Telekom Slovenije, PE Ljubljana" };
            var post1550 = new Post { PostNumber = 1550, PostName = "Ljubljana RTV Slovenija" };
            var post1600 = new Post { PostNumber = 1600, PostName = "Ljubljana Pošta Slovenije d.o.o., PE Ljubljana" };
            var post2000 = new Post { PostNumber = 2000, PostName = "Maribor" };
            var post2001 = new Post { PostNumber = 2001, PostName = "Maribor" };
            var post2002 = new Post { PostNumber = 2002, PostName = "Maribor - poštni center" };
            var post2201 = new Post { PostNumber = 2201, PostName = "Zgornja Kungota" };
            var post2204 = new Post { PostNumber = 2204, PostName = "Miklavž na Dravskem polju" };
            var post2205 = new Post { PostNumber = 2205, PostName = "Starše" };
            var post2206 = new Post { PostNumber = 2206, PostName = "Marjeta na Dravskem polju" };
            var post2208 = new Post { PostNumber = 2208, PostName = "Pohorje" };
            var post2211 = new Post { PostNumber = 2211, PostName = "Pesnica pri Mariboru" };
            var post2212 = new Post { PostNumber = 2212, PostName = "Šentilj v Slovenskih goricah" };
            var post2213 = new Post { PostNumber = 2213, PostName = "Zgornja Velka" };
            var post2214 = new Post { PostNumber = 2214, PostName = "Sladki Vrh" };
            var post2215 = new Post { PostNumber = 2215, PostName = "Ceršak" };
            var post2221 = new Post { PostNumber = 2221, PostName = "Jarenina" };
            var post2222 = new Post { PostNumber = 2222, PostName = "Jakobski Dol" };
            var post2223 = new Post { PostNumber = 2223, PostName = "Jurovski Dol" };
            var post2229 = new Post { PostNumber = 2229, PostName = "Malečnik" };
            var post2230 = new Post { PostNumber = 2230, PostName = "Lenart v Slovenskih goricah" };
            var post2231 = new Post { PostNumber = 2231, PostName = "Pernica" };
            var post2232 = new Post { PostNumber = 2232, PostName = "Voličina" };
            var post2233 = new Post { PostNumber = 2233, PostName = "Sveta Ana v Slovenskih goricah" };
            var post2234 = new Post { PostNumber = 2234, PostName = "Benedikt" };
            var post2235 = new Post { PostNumber = 2235, PostName = "Sveta Trojica v Slovenskih goricah" };
            var post2236 = new Post { PostNumber = 2236, PostName = "Cerkvenjak" };
            var post2241 = new Post { PostNumber = 2241, PostName = "Spodnji Duplek" };
            var post2242 = new Post { PostNumber = 2242, PostName = "Zgornja Korena" };
            var post2250 = new Post { PostNumber = 2250, PostName = "Ptuj" };
            var post2252 = new Post { PostNumber = 2252, PostName = "Dornava" };
            var post2253 = new Post { PostNumber = 2253, PostName = "Destrnik" };
            var post2254 = new Post { PostNumber = 2254, PostName = "Trnovska vas" };
            var post2255 = new Post { PostNumber = 2255, PostName = "Vitomarci" };
            var post2256 = new Post { PostNumber = 2256, PostName = "Juršinci" };
            var post2257 = new Post { PostNumber = 2257, PostName = "Polenšak" };
            var post2258 = new Post { PostNumber = 2258, PostName = "Sveti Tomaž" };
            var post2259 = new Post { PostNumber = 2259, PostName = "Ivanjkovci" };
            var post2270 = new Post { PostNumber = 2270, PostName = "Ormož" };
            var post2272 = new Post { PostNumber = 2272, PostName = "Gorišnica" };
            var post2273 = new Post { PostNumber = 2273, PostName = "Podgorci" };
            var post2274 = new Post { PostNumber = 2274, PostName = "Velika Nedelja" };
            var post2275 = new Post { PostNumber = 2275, PostName = "Miklavž pri Ormožu" };
            var post2276 = new Post { PostNumber = 2276, PostName = "Kog" };
            var post2277 = new Post { PostNumber = 2277, PostName = "Središče ob Dravi" };
            var post2281 = new Post { PostNumber = 2281, PostName = "Markovci" };
            var post2282 = new Post { PostNumber = 2282, PostName = "Cirkulane" };
            var post2283 = new Post { PostNumber = 2283, PostName = "Zavrč" };
            var post2284 = new Post { PostNumber = 2284, PostName = "Videm pri Ptuju" };
            var post2285 = new Post { PostNumber = 2285, PostName = "Zgornji Leskovec" };
            var post2286 = new Post { PostNumber = 2286, PostName = "Podlehnik" };
            var post2287 = new Post { PostNumber = 2287, PostName = "Žetale" };
            var post2288 = new Post { PostNumber = 2288, PostName = "Hajdina" };
            var post2289 = new Post { PostNumber = 2289, PostName = "Stoperce" };
            var post2310 = new Post { PostNumber = 2310, PostName = "Slovenska Bistrica" };
            var post2311 = new Post { PostNumber = 2311, PostName = "Hoče" };
            var post2312 = new Post { PostNumber = 2312, PostName = "Orehova vas" };
            var post2313 = new Post { PostNumber = 2313, PostName = "Fram" };
            var post2314 = new Post { PostNumber = 2314, PostName = "Zgornja Polskava" };
            var post2315 = new Post { PostNumber = 2315, PostName = "Šmartno na Pohorju" };
            var post2316 = new Post { PostNumber = 2316, PostName = "Zgornja Ložnica" };
            var post2317 = new Post { PostNumber = 2317, PostName = "Oplotnica" };
            var post2318 = new Post { PostNumber = 2318, PostName = "Laporje" };
            var post2319 = new Post { PostNumber = 2319, PostName = "Poljčane" };
            var post2321 = new Post { PostNumber = 2321, PostName = "Makole" };
            var post2322 = new Post { PostNumber = 2322, PostName = "Majšperk" };
            var post2323 = new Post { PostNumber = 2323, PostName = "Ptujska Gora" };
            var post2324 = new Post { PostNumber = 2324, PostName = "Lovrenc na Dravskem polju" };
            var post2325 = new Post { PostNumber = 2325, PostName = "Kidričevo" };
            var post2326 = new Post { PostNumber = 2326, PostName = "Cirkovce" };
            var post2327 = new Post { PostNumber = 2327, PostName = "Rače" };
            var post2331 = new Post { PostNumber = 2331, PostName = "Pragersko" };
            var post2341 = new Post { PostNumber = 2341, PostName = "Limbuš" };
            var post2342 = new Post { PostNumber = 2342, PostName = "Ruše" };
            var post2343 = new Post { PostNumber = 2343, PostName = "Fala" };
            var post2344 = new Post { PostNumber = 2344, PostName = "Lovrenc na Pohorju" };
            var post2345 = new Post { PostNumber = 2345, PostName = "Bistrica ob Dravi" };
            var post2351 = new Post { PostNumber = 2351, PostName = "Kamnica" };
            var post2352 = new Post { PostNumber = 2352, PostName = "Selnica ob Dravi" };
            var post2353 = new Post { PostNumber = 2353, PostName = "Sv.Duh na Ostrem Vrhu" };
            var post2354 = new Post { PostNumber = 2354, PostName = "Bresternica" };
            var post2360 = new Post { PostNumber = 2360, PostName = "Radlje ob Dravi" };
            var post2361 = new Post { PostNumber = 2361, PostName = "Ožbalt" };
            var post2362 = new Post { PostNumber = 2362, PostName = "Kapla" };
            var post2363 = new Post { PostNumber = 2363, PostName = "Podvelka" };
            var post2364 = new Post { PostNumber = 2364, PostName = "Ribnica na Pohorju" };
            var post2365 = new Post { PostNumber = 2365, PostName = "Vuhred" };
            var post2366 = new Post { PostNumber = 2366, PostName = "Muta" };
            var post2367 = new Post { PostNumber = 2367, PostName = "Vuzenica" };
            var post2370 = new Post { PostNumber = 2370, PostName = "Dravograd" };
            var post2371 = new Post { PostNumber = 2371, PostName = "Trbonje" };
            var post2372 = new Post { PostNumber = 2372, PostName = "Libeliče" };
            var post2373 = new Post { PostNumber = 2373, PostName = "Šentjanž pri Dravogradu" };
            var post2380 = new Post { PostNumber = 2380, PostName = "Slovenj Gradec" };
            var post2381 = new Post { PostNumber = 2381, PostName = "Podgorje pri Slovenj Gradcu" };
            var post2382 = new Post { PostNumber = 2382, PostName = "Mislinja" };
            var post2383 = new Post { PostNumber = 2383, PostName = "Šmartno pri Slovenj Gradcu" };
            var post2390 = new Post { PostNumber = 2390, PostName = "Ravne na Koroškem" };
            var post2391 = new Post { PostNumber = 2391, PostName = "Prevalje" };
            var post2392 = new Post { PostNumber = 2392, PostName = "Mežica" };
            var post2393 = new Post { PostNumber = 2393, PostName = "črna na Koroškem" };
            var post2394 = new Post { PostNumber = 2394, PostName = "Kotlje" };
            var post2500 = new Post { PostNumber = 2500, PostName = "Maribor Pošta Slovenije d.o.o." };
            var post2501 = new Post { PostNumber = 2501, PostName = "Maribor Upravna enota Maribor" };
            var post2502 = new Post { PostNumber = 2502, PostName = "Maribor Davčna uprava RS, izpostava Maribor" };
            var post2503 = new Post { PostNumber = 2503, PostName = "Maribor Okrajno in okrožno sodišče v Mariboru" };
            var post2504 = new Post { PostNumber = 2504, PostName = "Maribor Večer" };
            var post2505 = new Post { PostNumber = 2505, PostName = "Maribor Nova Kreditna banka Maribor" };
            var post2506 = new Post { PostNumber = 2506, PostName = "Maribor Henkel Slovenija" };
            var post2507 = new Post { PostNumber = 2507, PostName = "Maribor Zavarovalnica Maribor" };
            var post2508 = new Post { PostNumber = 2508, PostName = "Maribor Okrajno sodišče v Mariboru" };
            var post2509 = new Post { PostNumber = 2509, PostName = "Maribor Elektro Maribor" };
            var post2600 = new Post { PostNumber = 2600, PostName = "Maribor Pošta Slovenije d.o.o., PE Maribor" };
            var post2603 = new Post { PostNumber = 2603, PostName = "Maribor Pošta Slovenije d.o.o., Skladišče Maribor" };
            var post2607 = new Post { PostNumber = 2607, PostName = "Maribor - center za digitalizacijo Pošta Slovenije d.o.o." };
            var post2609 = new Post { PostNumber = 2609, PostName = "Maribor Pošta Slovenije d.o.o., Paketni ekspedit" };
            var post2610 = new Post { PostNumber = 2610, PostName = "Maribor Pošta Slovenije d.o.o., Centralna RA pisarna" };
            var post3000 = new Post { PostNumber = 3000, PostName = "Celje" };
            var post3001 = new Post { PostNumber = 3001, PostName = "Celje" };
            var post3201 = new Post { PostNumber = 3201, PostName = "Šmartno v Rožni dolini" };
            var post3202 = new Post { PostNumber = 3202, PostName = "Ljubečna" };
            var post3203 = new Post { PostNumber = 3203, PostName = "Nova Cerkev" };
            var post3204 = new Post { PostNumber = 3204, PostName = "Dobrna" };
            var post3205 = new Post { PostNumber = 3205, PostName = "Vitanje" };
            var post3206 = new Post { PostNumber = 3206, PostName = "Stranice" };
            var post3210 = new Post { PostNumber = 3210, PostName = "Slovenske Konjice" };
            var post3211 = new Post { PostNumber = 3211, PostName = "Škofja vas" };
            var post3212 = new Post { PostNumber = 3212, PostName = "Vojnik" };
            var post3213 = new Post { PostNumber = 3213, PostName = "Frankolovo" };
            var post3214 = new Post { PostNumber = 3214, PostName = "Zreče" };
            var post3215 = new Post { PostNumber = 3215, PostName = "Loče" };
            var post3220 = new Post { PostNumber = 3220, PostName = "Štore" };
            var post3221 = new Post { PostNumber = 3221, PostName = "Teharje" };
            var post3222 = new Post { PostNumber = 3222, PostName = "Dramlje" };
            var post3223 = new Post { PostNumber = 3223, PostName = "Loka pri Žusmu" };
            var post3224 = new Post { PostNumber = 3224, PostName = "Dobje pri Planini" };
            var post3225 = new Post { PostNumber = 3225, PostName = "Planina pri Sevnici" };
            var post3230 = new Post { PostNumber = 3230, PostName = "Šentjur" };
            var post3231 = new Post { PostNumber = 3231, PostName = "Grobelno" };
            var post3232 = new Post { PostNumber = 3232, PostName = "Ponikva" };
            var post3233 = new Post { PostNumber = 3233, PostName = "Kalobje" };
            var post3240 = new Post { PostNumber = 3240, PostName = "Šmarje pri Jelšah" };
            var post3241 = new Post { PostNumber = 3241, PostName = "Podplat" };
            var post3250 = new Post { PostNumber = 3250, PostName = "Rogaška Slatina" };
            var post3252 = new Post { PostNumber = 3252, PostName = "Rogatec" };
            var post3253 = new Post { PostNumber = 3253, PostName = "Pristava pri Mestinju" };
            var post3254 = new Post { PostNumber = 3254, PostName = "Podčetrtek" };
            var post3255 = new Post { PostNumber = 3255, PostName = "Buče" };
            var post3256 = new Post { PostNumber = 3256, PostName = "Bistrica ob Sotli" };
            var post3257 = new Post { PostNumber = 3257, PostName = "Podsreda" };
            var post3260 = new Post { PostNumber = 3260, PostName = "Kozje" };
            var post3261 = new Post { PostNumber = 3261, PostName = "Lesično" };
            var post3262 = new Post { PostNumber = 3262, PostName = "Prevorje" };
            var post3263 = new Post { PostNumber = 3263, PostName = "Gorica pri Slivnici" };
            var post3264 = new Post { PostNumber = 3264, PostName = "Sveti Štefan" };
            var post3270 = new Post { PostNumber = 3270, PostName = "Laško" };
            var post3271 = new Post { PostNumber = 3271, PostName = "Šentrupert" };
            var post3272 = new Post { PostNumber = 3272, PostName = "Rimske Toplice" };
            var post3273 = new Post { PostNumber = 3273, PostName = "Jurklošter" };
            var post3301 = new Post { PostNumber = 3301, PostName = "Petrovče" };
            var post3302 = new Post { PostNumber = 3302, PostName = "Griže" };
            var post3303 = new Post { PostNumber = 3303, PostName = "Gomilsko" };
            var post3304 = new Post { PostNumber = 3304, PostName = "Tabor" };
            var post3305 = new Post { PostNumber = 3305, PostName = "Vransko" };
            var post3310 = new Post { PostNumber = 3310, PostName = "Žalec" };
            var post3311 = new Post { PostNumber = 3311, PostName = "Šempeter v Savinjski dolini" };
            var post3312 = new Post { PostNumber = 3312, PostName = "Prebold" };
            var post3313 = new Post { PostNumber = 3313, PostName = "Polzela" };
            var post3314 = new Post { PostNumber = 3314, PostName = "Braslovče" };
            var post3320 = new Post { PostNumber = 3320, PostName = "Velenje" };
            var post3322 = new Post { PostNumber = 3322, PostName = "Velenje" };
            var post3325 = new Post { PostNumber = 3325, PostName = "Šoštanj" };
            var post3326 = new Post { PostNumber = 3326, PostName = "Topolšica" };
            var post3327 = new Post { PostNumber = 3327, PostName = "Šmartno ob Paki" };
            var post3330 = new Post { PostNumber = 3330, PostName = "Mozirje" };
            var post3331 = new Post { PostNumber = 3331, PostName = "Nazarje" };
            var post3332 = new Post { PostNumber = 3332, PostName = "Rečica ob Savinji" };
            var post3333 = new Post { PostNumber = 3333, PostName = "Ljubno ob Savinji" };
            var post3334 = new Post { PostNumber = 3334, PostName = "Luče" };
            var post3335 = new Post { PostNumber = 3335, PostName = "Solčava" };
            var post3341 = new Post { PostNumber = 3341, PostName = "Šmartno ob Dreti" };
            var post3342 = new Post { PostNumber = 3342, PostName = "Gornji Grad" };
            var post3503 = new Post { PostNumber = 3503, PostName = "Velenje Gorenje" };
            var post3504 = new Post { PostNumber = 3504, PostName = "Velenje ERA" };
            var post3505 = new Post { PostNumber = 3505, PostName = "Celje Merkur" };
            var post3600 = new Post { PostNumber = 3600, PostName = "Celje Pošta Slovenije d.o.o., PE Celje" };
            var post4000 = new Post { PostNumber = 4000, PostName = "Kranj" };
            var post4001 = new Post { PostNumber = 4001, PostName = "Kranj" };
            var post4200 = new Post { PostNumber = 4200, PostName = "Kranj Pošta Slovenije d.o.o, PPP Šenčur" };
            var post4201 = new Post { PostNumber = 4201, PostName = "Zgornja Besnica" };
            var post4202 = new Post { PostNumber = 4202, PostName = "Naklo" };
            var post4203 = new Post { PostNumber = 4203, PostName = "Duplje" };
            var post4204 = new Post { PostNumber = 4204, PostName = "Golnik" };
            var post4205 = new Post { PostNumber = 4205, PostName = "Preddvor" };
            var post4206 = new Post { PostNumber = 4206, PostName = "Zgornje Jezersko" };
            var post4207 = new Post { PostNumber = 4207, PostName = "Cerklje na Gorenjskem" };
            var post4208 = new Post { PostNumber = 4208, PostName = "Šenčur" };
            var post4209 = new Post { PostNumber = 4209, PostName = "Žabnica" };
            var post4210 = new Post { PostNumber = 4210, PostName = "Brnik - aerodrom" };
            var post4211 = new Post { PostNumber = 4211, PostName = "Mavčiče" };
            var post4212 = new Post { PostNumber = 4212, PostName = "Visoko" };
            var post4220 = new Post { PostNumber = 4220, PostName = "Škofja Loka" };
            var post4223 = new Post { PostNumber = 4223, PostName = "Poljane nad Škofjo Loko" };
            var post4224 = new Post { PostNumber = 4224, PostName = "Gorenja vas" };
            var post4225 = new Post { PostNumber = 4225, PostName = "Sovodenj" };
            var post4226 = new Post { PostNumber = 4226, PostName = "Žiri" };
            var post4227 = new Post { PostNumber = 4227, PostName = "Selca" };
            var post4228 = new Post { PostNumber = 4228, PostName = "Železniki" };
            var post4229 = new Post { PostNumber = 4229, PostName = "Sorica" };
            var post4240 = new Post { PostNumber = 4240, PostName = "Radovljica" };
            var post4243 = new Post { PostNumber = 4243, PostName = "Brezje" };
            var post4244 = new Post { PostNumber = 4244, PostName = "Podnart" };
            var post4245 = new Post { PostNumber = 4245, PostName = "Kropa" };
            var post4246 = new Post { PostNumber = 4246, PostName = "Kamna Gorica" };
            var post4247 = new Post { PostNumber = 4247, PostName = "Zgornje Gorje" };
            var post4248 = new Post { PostNumber = 4248, PostName = "Lesce" };
            var post4260 = new Post { PostNumber = 4260, PostName = "Bled" };
            var post4263 = new Post { PostNumber = 4263, PostName = "Bohinjska Bela" };
            var post4264 = new Post { PostNumber = 4264, PostName = "Bohinjska Bistrica" };
            var post4265 = new Post { PostNumber = 4265, PostName = "Bohinjsko jezero" };
            var post4267 = new Post { PostNumber = 4267, PostName = "Srednja vas v Bohinju" };
            var post4270 = new Post { PostNumber = 4270, PostName = "Jesenice" };
            var post4273 = new Post { PostNumber = 4273, PostName = "Blejska Dobrava" };
            var post4274 = new Post { PostNumber = 4274, PostName = "Žirovnica" };
            var post4275 = new Post { PostNumber = 4275, PostName = "Begunje na Gorenjskem" };
            var post4276 = new Post { PostNumber = 4276, PostName = "Hrušica" };
            var post4280 = new Post { PostNumber = 4280, PostName = "Kranjska Gora" };
            var post4281 = new Post { PostNumber = 4281, PostName = "Mojstrana" };
            var post4282 = new Post { PostNumber = 4282, PostName = "Gozd Martuljek" };
            var post4283 = new Post { PostNumber = 4283, PostName = "Rateče - Planica" };
            var post4290 = new Post { PostNumber = 4290, PostName = "Tržič" };
            var post4294 = new Post { PostNumber = 4294, PostName = "Križe" };
            var post4501 = new Post { PostNumber = 4501, PostName = "NakloMerkur" };
            var post4502 = new Post { PostNumber = 4502, PostName = "Kranj Sava" };
            var post4600 = new Post { PostNumber = 4600, PostName = "Kranj Pošta Slovenije d.o.o., PE Kranj" };
            var post5000 = new Post { PostNumber = 5000, PostName = "Nova Gorica" };
            var post5001 = new Post { PostNumber = 5001, PostName = "Nova Gorica" };
            var post5210 = new Post { PostNumber = 5210, PostName = "Deskle" };
            var post5211 = new Post { PostNumber = 5211, PostName = "Kojsko" };
            var post5212 = new Post { PostNumber = 5212, PostName = "Dobrovo v Brdih" };
            var post5213 = new Post { PostNumber = 5213, PostName = "Kanal" };
            var post5214 = new Post { PostNumber = 5214, PostName = "Kal nad Kanalom" };
            var post5215 = new Post { PostNumber = 5215, PostName = "Ročinj" };
            var post5216 = new Post { PostNumber = 5216, PostName = "Most na Soči" };
            var post5220 = new Post { PostNumber = 5220, PostName = "Tolmin" };
            var post5222 = new Post { PostNumber = 5222, PostName = "Kobarid" };
            var post5223 = new Post { PostNumber = 5223, PostName = "Breginj" };
            var post5224 = new Post { PostNumber = 5224, PostName = "Srpenica" };
            var post5230 = new Post { PostNumber = 5230, PostName = "Bovec" };
            var post5231 = new Post { PostNumber = 5231, PostName = "Log pod Mangartom" };
            var post5232 = new Post { PostNumber = 5232, PostName = "Soča" };
            var post5242 = new Post { PostNumber = 5242, PostName = "Grahovo ob Bači" };
            var post5243 = new Post { PostNumber = 5243, PostName = "Podbrdo" };
            var post5250 = new Post { PostNumber = 5250, PostName = "Solkan" };
            var post5251 = new Post { PostNumber = 5251, PostName = "Grgar" };
            var post5252 = new Post { PostNumber = 5252, PostName = "Trnovo pri Gorici" };
            var post5253 = new Post { PostNumber = 5253, PostName = "čepovan" };
            var post5261 = new Post { PostNumber = 5261, PostName = "Šempas" };
            var post5262 = new Post { PostNumber = 5262, PostName = "črniče" };
            var post5263 = new Post { PostNumber = 5263, PostName = "Dobravlje" };
            var post5270 = new Post { PostNumber = 5270, PostName = "Ajdovščina" };
            var post5271 = new Post { PostNumber = 5271, PostName = "Vipava" };
            var post5272 = new Post { PostNumber = 5272, PostName = "Podnanos" };
            var post5273 = new Post { PostNumber = 5273, PostName = "Col" };
            var post5274 = new Post { PostNumber = 5274, PostName = "črni Vrh nad Idrijo" };
            var post5275 = new Post { PostNumber = 5275, PostName = "Godovič" };
            var post5280 = new Post { PostNumber = 5280, PostName = "Idrija" };
            var post5281 = new Post { PostNumber = 5281, PostName = "Spodnja Idrija" };
            var post5282 = new Post { PostNumber = 5282, PostName = "Cerkno" };
            var post5283 = new Post { PostNumber = 5283, PostName = "Slap ob Idrijci" };
            var post5290 = new Post { PostNumber = 5290, PostName = "Šempeter pri Gorici" };
            var post5291 = new Post { PostNumber = 5291, PostName = "Miren" };
            var post5292 = new Post { PostNumber = 5292, PostName = "Renče" };
            var post5293 = new Post { PostNumber = 5293, PostName = "Volčja Draga" };
            var post5294 = new Post { PostNumber = 5294, PostName = "Dornberk" };
            var post5295 = new Post { PostNumber = 5295, PostName = "Branik" };
            var post5296 = new Post { PostNumber = 5296, PostName = "Kostanjevica na Krasu" };
            var post5297 = new Post { PostNumber = 5297, PostName = "Prvačina" };
            var post5600 = new Post { PostNumber = 5600, PostName = "Nova Gorica Pošta Slovenije d.o.o., PE Nova Gorica" };
            var post6000 = new Post { PostNumber = 6000, PostName = "Koper - Capodistria" };
            var post6001 = new Post { PostNumber = 6001, PostName = "Koper - Capodistria" };
            var post6200 = new Post { PostNumber = 6200, PostName = "Koper - CapodistriaPošta Slovenije d.o.o., PPP Koper" };
            var post6210 = new Post { PostNumber = 6210, PostName = "Sežana" };
            var post6215 = new Post { PostNumber = 6215, PostName = "Divača" };
            var post6216 = new Post { PostNumber = 6216, PostName = "Podgorje" };
            var post6217 = new Post { PostNumber = 6217, PostName = "Vremski Britof" };
            var post6219 = new Post { PostNumber = 6219, PostName = "Lokev" };
            var post6221 = new Post { PostNumber = 6221, PostName = "Dutovlje" };
            var post6222 = new Post { PostNumber = 6222, PostName = "Štanjel" };
            var post6223 = new Post { PostNumber = 6223, PostName = "Komen" };
            var post6224 = new Post { PostNumber = 6224, PostName = "Senožeče" };
            var post6225 = new Post { PostNumber = 6225, PostName = "Hruševje" };
            var post6230 = new Post { PostNumber = 6230, PostName = "Postojna" };
            var post6232 = new Post { PostNumber = 6232, PostName = "Planina" };
            var post6240 = new Post { PostNumber = 6240, PostName = "Kozina" };
            var post6242 = new Post { PostNumber = 6242, PostName = "Materija" };
            var post6243 = new Post { PostNumber = 6243, PostName = "Obrov" };
            var post6244 = new Post { PostNumber = 6244, PostName = "Podgrad" };
            var post6250 = new Post { PostNumber = 6250, PostName = "Ilirska Bistrica" };
            var post6251 = new Post { PostNumber = 6251, PostName = "Ilirska Bistrica - Trnovo" };
            var post6253 = new Post { PostNumber = 6253, PostName = "Knežak" };
            var post6254 = new Post { PostNumber = 6254, PostName = "Jelšane" };
            var post6255 = new Post { PostNumber = 6255, PostName = "Prem" };
            var post6256 = new Post { PostNumber = 6256, PostName = "Košana" };
            var post6257 = new Post { PostNumber = 6257, PostName = "Pivka" };
            var post6258 = new Post { PostNumber = 6258, PostName = "Prestranek" };
            var post6271 = new Post { PostNumber = 6271, PostName = "Dekani" };
            var post6272 = new Post { PostNumber = 6272, PostName = "Gračišče" };
            var post6273 = new Post { PostNumber = 6273, PostName = "Marezige" };
            var post6274 = new Post { PostNumber = 6274, PostName = "Šmarje" };
            var post6275 = new Post { PostNumber = 6275, PostName = "črni Kal" };
            var post6276 = new Post { PostNumber = 6276, PostName = "Pobegi" };
            var post6280 = new Post { PostNumber = 6280, PostName = "Ankaran / Ancarano" };
            var post6281 = new Post { PostNumber = 6281, PostName = "Škofije" };
            var post6310 = new Post { PostNumber = 6310, PostName = "Izola / Isola" };
            var post6320 = new Post { PostNumber = 6320, PostName = "Portorož / Portoroe" };
            var post6330 = new Post { PostNumber = 6330, PostName = "Piran / Pirano" };
            var post6333 = new Post { PostNumber = 6333, PostName = "Sečovlje / Sicciole" };
            var post6501 = new Post { PostNumber = 6501, PostName = "Koper - CapodistriaLuka Koper" };
            var post6502 = new Post { PostNumber = 6502, PostName = "Koper - CapodistriaBanka Koper" };
            var post6503 = new Post { PostNumber = 6503, PostName = "Koper - CapodistriaAdriatic zavarovalna družba" };
            var post6504 = new Post { PostNumber = 6504, PostName = "Koper - CapodistriaIntereuropa Koper" };
            var post6600 = new Post { PostNumber = 6600, PostName = "Koper - CapodistriaPošta Slovenije d.o.o., PE Koper" };
            var post8000 = new Post { PostNumber = 8000, PostName = "Novo mesto" };
            var post8001 = new Post { PostNumber = 8001, PostName = "Novo mesto" };
            var post8210 = new Post { PostNumber = 8210, PostName = "Trebnje" };
            var post8211 = new Post { PostNumber = 8211, PostName = "Dobrnič" };
            var post8212 = new Post { PostNumber = 8212, PostName = "Velika Loka" };
            var post8213 = new Post { PostNumber = 8213, PostName = "Veliki Gaber" };
            var post8216 = new Post { PostNumber = 8216, PostName = "Mirna Peč" };
            var post8220 = new Post { PostNumber = 8220, PostName = "Šmarješke Toplice" };
            var post8222 = new Post { PostNumber = 8222, PostName = "Otočec" };
            var post8230 = new Post { PostNumber = 8230, PostName = "Mokronog" };
            var post8231 = new Post { PostNumber = 8231, PostName = "Trebelno" };
            var post8232 = new Post { PostNumber = 8232, PostName = "Šentrupert" };
            var post8233 = new Post { PostNumber = 8233, PostName = "Mirna" };
            var post8250 = new Post { PostNumber = 8250, PostName = "Brežice" };
            var post8251 = new Post { PostNumber = 8251, PostName = "čatež ob Savi" };
            var post8253 = new Post { PostNumber = 8253, PostName = "Artiče" };
            var post8254 = new Post { PostNumber = 8254, PostName = "Globoko" };
            var post8255 = new Post { PostNumber = 8255, PostName = "Pišece" };
            var post8256 = new Post { PostNumber = 8256, PostName = "Sromlje" };
            var post8257 = new Post { PostNumber = 8257, PostName = "Dobova" };
            var post8258 = new Post { PostNumber = 8258, PostName = "Kapele" };
            var post8259 = new Post { PostNumber = 8259, PostName = "Bizeljsko" };
            var post8261 = new Post { PostNumber = 8261, PostName = "Jesenice na Dolenjskem" };
            var post8262 = new Post { PostNumber = 8262, PostName = "Krška vas" };
            var post8263 = new Post { PostNumber = 8263, PostName = "Cerklje ob Krki" };
            var post8270 = new Post { PostNumber = 8270, PostName = "Krško" };
            var post8272 = new Post { PostNumber = 8272, PostName = "Zdole" };
            var post8273 = new Post { PostNumber = 8273, PostName = "Leskovec pri Krškem" };
            var post8274 = new Post { PostNumber = 8274, PostName = "Raka" };
            var post8275 = new Post { PostNumber = 8275, PostName = "Škocjan" };
            var post8276 = new Post { PostNumber = 8276, PostName = "Bučka" };
            var post8280 = new Post { PostNumber = 8280, PostName = "Brestanica" };
            var post8281 = new Post { PostNumber = 8281, PostName = "Senovo" };
            var post8282 = new Post { PostNumber = 8282, PostName = "Koprivnica" };
            var post8283 = new Post { PostNumber = 8283, PostName = "Blanca" };
            var post8290 = new Post { PostNumber = 8290, PostName = "Sevnica" };
            var post8292 = new Post { PostNumber = 8292, PostName = "Zabukovje" };
            var post8293 = new Post { PostNumber = 8293, PostName = "Studenec" };
            var post8294 = new Post { PostNumber = 8294, PostName = "Boštanj" };
            var post8295 = new Post { PostNumber = 8295, PostName = "Tržišče" };
            var post8296 = new Post { PostNumber = 8296, PostName = "Krmelj" };
            var post8297 = new Post { PostNumber = 8297, PostName = "Šentjanž" };
            var post8310 = new Post { PostNumber = 8310, PostName = "Šentjernej" };
            var post8311 = new Post { PostNumber = 8311, PostName = "Kostanjevica na Krki" };
            var post8312 = new Post { PostNumber = 8312, PostName = "Podbočje" };
            var post8321 = new Post { PostNumber = 8321, PostName = "Brusnice" };
            var post8322 = new Post { PostNumber = 8322, PostName = "Stopiče" };
            var post8323 = new Post { PostNumber = 8323, PostName = "Uršna sela" };
            var post8330 = new Post { PostNumber = 8330, PostName = "Metlika" };
            var post8331 = new Post { PostNumber = 8331, PostName = "Suhor" };
            var post8332 = new Post { PostNumber = 8332, PostName = "Gradac" };
            var post8333 = new Post { PostNumber = 8333, PostName = "Semič" };
            var post8340 = new Post { PostNumber = 8340, PostName = "črnomelj" };
            var post8341 = new Post { PostNumber = 8341, PostName = "Adlešiči" };
            var post8342 = new Post { PostNumber = 8342, PostName = "Stari trg ob Kolpi" };
            var post8343 = new Post { PostNumber = 8343, PostName = "Dragatuš" };
            var post8344 = new Post { PostNumber = 8344, PostName = "Vinica" };
            var post8350 = new Post { PostNumber = 8350, PostName = "Dolenjske Toplice" };
            var post8351 = new Post { PostNumber = 8351, PostName = "Straža" };
            var post8360 = new Post { PostNumber = 8360, PostName = "Žužemberk" };
            var post8361 = new Post { PostNumber = 8361, PostName = "Dvor" };
            var post8362 = new Post { PostNumber = 8362, PostName = "Hinje" };
            var post8501 = new Post { PostNumber = 8501, PostName = "Novo mesto Krka" };
            var post8600 = new Post { PostNumber = 8600, PostName = "Nova mesto Pošta Slovenije d.o.o., PE Novo mesto" };
            var post9000 = new Post { PostNumber = 9000, PostName = "Murska Sobota" };
            var post9001 = new Post { PostNumber = 9001, PostName = "Murska Sobota" };
            var post9201 = new Post { PostNumber = 9201, PostName = "Puconci" };
            var post9202 = new Post { PostNumber = 9202, PostName = "Mačkovci" };
            var post9203 = new Post { PostNumber = 9203, PostName = "Petrovci" };
            var post9204 = new Post { PostNumber = 9204, PostName = "Šalovci" };
            var post9205 = new Post { PostNumber = 9205, PostName = "Hodoš / Hodos" };
            var post9206 = new Post { PostNumber = 9206, PostName = "Križevci" };
            var post9207 = new Post { PostNumber = 9207, PostName = "Prosenjakovci / Partosfalva" };
            var post9208 = new Post { PostNumber = 9208, PostName = "Fokovci" };
            var post9220 = new Post { PostNumber = 9220, PostName = "Lendava / Lendva" };
            var post9221 = new Post { PostNumber = 9221, PostName = "Martjanci" };
            var post9222 = new Post { PostNumber = 9222, PostName = "Bogojina" };
            var post9223 = new Post { PostNumber = 9223, PostName = "Dobrovnik / Dobronak" };
            var post9224 = new Post { PostNumber = 9224, PostName = "Turnišče" };
            var post9225 = new Post { PostNumber = 9225, PostName = "Velika Polana" };
            var post9226 = new Post { PostNumber = 9226, PostName = "Moravske Toplice" };
            var post9227 = new Post { PostNumber = 9227, PostName = "Kobilje" };
            var post9231 = new Post { PostNumber = 9231, PostName = "Beltinci" };
            var post9232 = new Post { PostNumber = 9232, PostName = "črenšovci" };
            var post9233 = new Post { PostNumber = 9233, PostName = "Odranci" };
            var post9240 = new Post { PostNumber = 9240, PostName = "Ljutomer" };
            var post9241 = new Post { PostNumber = 9241, PostName = "Veržej" };
            var post9242 = new Post { PostNumber = 9242, PostName = "Križevci pri Ljutomeru" };
            var post9243 = new Post { PostNumber = 9243, PostName = "Mala Nedelja" };
            var post9244 = new Post { PostNumber = 9244, PostName = "Sveti Jurij ob Ščavnici" };
            var post9245 = new Post { PostNumber = 9245, PostName = "Spodnji Ivanjci" };
            var post9246 = new Post { PostNumber = 9246, PostName = "Razkrižje" };
            var post9250 = new Post { PostNumber = 9250, PostName = "Gornja Radgona" };
            var post9251 = new Post { PostNumber = 9251, PostName = "Tišina" };
            var post9252 = new Post { PostNumber = 9252, PostName = "Radenci" };
            var post9253 = new Post { PostNumber = 9253, PostName = "Apače" };
            var post9261 = new Post { PostNumber = 9261, PostName = "Cankova" };
            var post9262 = new Post { PostNumber = 9262, PostName = "Rogašovci" };
            var post9263 = new Post { PostNumber = 9263, PostName = "Kuzma" };
            var post9264 = new Post { PostNumber = 9264, PostName = "Grad" };
            var post9265 = new Post { PostNumber = 9265, PostName = "Bodonci" };
            var post9501 = new Post { PostNumber = 9501, PostName = "Murska Sobota Mura" };
            var post9502 = new Post { PostNumber = 9502, PostName = "Radenci Radenska - Zdravilišče" };
            var post9600 = new Post { PostNumber = 9600, PostName = "Murska Sobota Pošta Slovenije d.o.o., PE Murska Sobota" };
            #region Post Inserts
            context.Posts.AddOrUpdate(
                p => p.PostNumber,
                post1000,
                post1001,
                post1002,
                post1004,
                post1210,
                post1211,
                post1215,
                post1216,
                post1217,
                post1218,
                post1219,
                post1221,
                post1222,
                post1223,
                post1225,
                post1230,
                post1231,
                post1233,
                post1234,
                post1235,
                post1236,
                post1241,
                post1242,
                post1251,
                post1252,
                post1260,
                post1261,
                post1262,
                post1270,
                post1272,
                post1273,
                post1274,
                post1275,
                post1276,
                post1281,
                post1282,
                post1290,
                post1291,
                post1292,
                post1293,
                post1294,
                post1295,
                post1296,
                post1301,
                post1303,
                post1310,
                post1311,
                post1312,
                post1313,
                post1314,
                post1315,
                post1316,
                post1317,
                post1318,
                post1319,
                post1330,
                post1331,
                post1332,
                post1336,
                post1337,
                post1338,
                post1351,
                post1352,
                post1353,
                post1354,
                post1355,
                post1356,
                post1357,
                post1358,
                post1360,
                post1370,
                post1372,
                post1373,
                post1380,
                post1381,
                post1382,
                post1384,
                post1385,
                post1386,
                post1410,
                post1411,
                post1412,
                post1413,
                post1414,
                post1420,
                post1423,
                post1430,
                post1431,
                post1432,
                post1433,
                post1434,
                post1501,
                post1502,
                post1503,
                post1504,
                post1505,
                post1506,
                post1507,
                post1509,
                post1510,
                post1511,
                post1512,
                post1513,
                post1514,
                post1516,
                post1517,
                post1518,
                post1519,
                post1520,
                post1521,
                post1522,
                post1523,
                post1524,
                post1525,
                post1526,
                post1527,
                post1528,
                post1529,
                post1532,
                post1533,
                post1534,
                post1535,
                post1536,
                post1537,
                post1538,
                post1540,
                post1542,
                post1543,
                post1544,
                post1545,
                post1546,
                post1547,
                post1550,
                post1600,
                post2000,
                post2001,
                post2002,
                post2201,
                post2204,
                post2205,
                post2206,
                post2208,
                post2211,
                post2212,
                post2213,
                post2214,
                post2215,
                post2221,
                post2222,
                post2223,
                post2229,
                post2230,
                post2231,
                post2232,
                post2233,
                post2234,
                post2235,
                post2236,
                post2241,
                post2242,
                post2250,
                post2252,
                post2253,
                post2254,
                post2255,
                post2256,
                post2257,
                post2258,
                post2259,
                post2270,
                post2272,
                post2273,
                post2274,
                post2275,
                post2276,
                post2277,
                post2281,
                post2282,
                post2283,
                post2284,
                post2285,
                post2286,
                post2287,
                post2288,
                post2289,
                post2310,
                post2311,
                post2312,
                post2313,
                post2314,
                post2315,
                post2316,
                post2317,
                post2318,
                post2319,
                post2321,
                post2322,
                post2323,
                post2324,
                post2325,
                post2326,
                post2327,
                post2331,
                post2341,
                post2342,
                post2343,
                post2344,
                post2345,
                post2351,
                post2352,
                post2353,
                post2354,
                post2360,
                post2361,
                post2362,
                post2363,
                post2364,
                post2365,
                post2366,
                post2367,
                post2370,
                post2371,
                post2372,
                post2373,
                post2380,
                post2381,
                post2382,
                post2383,
                post2390,
                post2391,
                post2392,
                post2393,
                post2394,
                post2500,
                post2501,
                post2502,
                post2503,
                post2504,
                post2505,
                post2506,
                post2507,
                post2508,
                post2509,
                post2600,
                post2603,
                post2607,
                post2609,
                post2610,
                post3000,
                post3001,
                post3201,
                post3202,
                post3203,
                post3204,
                post3205,
                post3206,
                post3210,
                post3211,
                post3212,
                post3213,
                post3214,
                post3215,
                post3220,
                post3221,
                post3222,
                post3223,
                post3224,
                post3225,
                post3230,
                post3231,
                post3232,
                post3233,
                post3240,
                post3241,
                post3250,
                post3252,
                post3253,
                post3254,
                post3255,
                post3256,
                post3257,
                post3260,
                post3261,
                post3262,
                post3263,
                post3264,
                post3270,
                post3271,
                post3272,
                post3273,
                post3301,
                post3302,
                post3303,
                post3304,
                post3305,
                post3310,
                post3311,
                post3312,
                post3313,
                post3314,
                post3320,
                post3322,
                post3325,
                post3326,
                post3327,
                post3330,
                post3331,
                post3332,
                post3333,
                post3334,
                post3335,
                post3341,
                post3342,
                post3503,
                post3504,
                post3505,
                post3600,
                post4000,
                post4001,
                post4200,
                post4201,
                post4202,
                post4203,
                post4204,
                post4205,
                post4206,
                post4207,
                post4208,
                post4209,
                post4210,
                post4211,
                post4212,
                post4220,
                post4223,
                post4224,
                post4225,
                post4226,
                post4227,
                post4228,
                post4229,
                post4240,
                post4243,
                post4244,
                post4245,
                post4246,
                post4247,
                post4248,
                post4260,
                post4263,
                post4264,
                post4265,
                post4267,
                post4270,
                post4273,
                post4274,
                post4275,
                post4276,
                post4280,
                post4281,
                post4282,
                post4283,
                post4290,
                post4294,
                post4501,
                post4502,
                post4600,
                post5000,
                post5001,
                post5210,
                post5211,
                post5212,
                post5213,
                post5214,
                post5215,
                post5216,
                post5220,
                post5222,
                post5223,
                post5224,
                post5230,
                post5231,
                post5232,
                post5242,
                post5243,
                post5250,
                post5251,
                post5252,
                post5253,
                post5261,
                post5262,
                post5263,
                post5270,
                post5271,
                post5272,
                post5273,
                post5274,
                post5275,
                post5280,
                post5281,
                post5282,
                post5283,
                post5290,
                post5291,
                post5292,
                post5293,
                post5294,
                post5295,
                post5296,
                post5297,
                post5600,
                post6000,
                post6001,
                post6200,
                post6210,
                post6215,
                post6216,
                post6217,
                post6219,
                post6221,
                post6222,
                post6223,
                post6224,
                post6225,
                post6230,
                post6232,
                post6240,
                post6242,
                post6243,
                post6244,
                post6250,
                post6251,
                post6253,
                post6254,
                post6255,
                post6256,
                post6257,
                post6258,
                post6271,
                post6272,
                post6273,
                post6274,
                post6275,
                post6276,
                post6280,
                post6281,
                post6310,
                post6320,
                post6330,
                post6333,
                post6501,
                post6502,
                post6503,
                post6504,
                post6600,
                post8000,
                post8001,
                post8210,
                post8211,
                post8212,
                post8213,
                post8216,
                post8220,
                post8222,
                post8230,
                post8231,
                post8232,
                post8233,
                post8250,
                post8251,
                post8253,
                post8254,
                post8255,
                post8256,
                post8257,
                post8258,
                post8259,
                post8261,
                post8262,
                post8263,
                post8270,
                post8272,
                post8273,
                post8274,
                post8275,
                post8276,
                post8280,
                post8281,
                post8282,
                post8283,
                post8290,
                post8292,
                post8293,
                post8294,
                post8295,
                post8296,
                post8297,
                post8310,
                post8311,
                post8312,
                post8321,
                post8322,
                post8323,
                post8330,
                post8331,
                post8332,
                post8333,
                post8340,
                post8341,
                post8342,
                post8343,
                post8344,
                post8350,
                post8351,
                post8360,
                post8361,
                post8362,
                post8501,
                post8600,
                post9000,
                post9001,
                post9201,
                post9202,
                post9203,
                post9204,
                post9205,
                post9206,
                post9207,
                post9208,
                post9220,
                post9221,
                post9222,
                post9223,
                post9224,
                post9225,
                post9226,
                post9227,
                post9231,
                post9232,
                post9233,
                post9240,
                post9241,
                post9242,
                post9243,
                post9244,
                post9245,
                post9246,
                post9250,
                post9251,
                post9252,
                post9253,
                post9261,
                post9262,
                post9263,
                post9264,
                post9265,
                post9501,
                post9502,
                post9600
            );
            #endregion
            #endregion

            #region HealthCareProviders
            var healthCareProvider0016 = new HealthCareProvider { Key = "00016", Name = "SB NOVA GORICA", Address = "LISKUR 19", Post = post5000 };
            var healthCareProvider0370 = new HealthCareProvider { Key = "00370", Name = "ZD ČRNOMELJ", Address = "VAJDOVA ULICA 9", Post = post8333 };
            var healthCareProvider0100 = new HealthCareProvider { Key = "00100", Name = "ZD BREŽICE", Address = "ČERNELČEVA CESTA 8", Post = post8250 };
            var healthCareProvider0374 = new HealthCareProvider { Key = "00374", Name = "SB NOVO MESTO", Address = "ŠMIHELSKA CESTA 1", Post = post8000 };
            var healthCareProvider2131 = new HealthCareProvider { Key = "02131", Name = "ZD CELJE", Address = "GREGORČIČEVA ULICA 5", Post = post3000 };
            var healthCareProvider3561 = new HealthCareProvider { Key = "03561", Name = "ZDRAVSTVENI DOM ILIRSKA", Address = "GREGORČIČEVA ULICA 8", Post = post6250 };
            var healthCareProvider4870 = new HealthCareProvider { Key = "04870", Name = "ZZV KRANJ", Address = "GOSPOSVETSKA ULICA 12", Post = post4000 };
            var healthCareProvider4131 = new HealthCareProvider { Key = "04131", Name = "PSIHIATRIČNA BOLNIŠNICA", Address = "BEGUNJE NA GORENJSKEM 55", Post = post4275 };
            var healthCareProvider6501 = new HealthCareProvider { Key = "06501", Name = "ŽZD LJUBLJANA", Address = "CELOVŠKA CESTA 4", Post = post1000 };
            var healthCareProvider7602 = new HealthCareProvider { Key = "07602", Name = "ZZV MARIBOR", Address = "PRVOMAJSKA ULICA 1", Post = post2000 };
            #region HealthCareProvider Inserts
            context.HealthCareProviders.AddOrUpdate(
                h => h.Key,
                healthCareProvider0016,
                healthCareProvider0370,
                healthCareProvider0100,
                healthCareProvider0374,
                healthCareProvider2131,
                healthCareProvider3561,
                healthCareProvider4870,
                healthCareProvider4131,
                healthCareProvider6501,
                healthCareProvider7602
            );
            #endregion
            #endregion

            #region Sprint3Entities
            AddOrUpdateDiseaseMedications(context, "I10", "Esencialna hipertenzija", "http://www.vitabalans.com/index.php?id=zopitin0004", "082392", "Enalapril Vitabalans 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I10", "Esencialna hipertenzija", "http://www.cbz.si/cbz/bazazdr2.nsf/o/F2D46D0FDF63B711C12579C2003F5E1A/$File/a-016418.pdf", "016470", "Piramil 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I10", "Esencialna hipertenzija", "http://www.krka.si/sl/zdravila-in-izdelki/zdravila-na-recept/enap/1323/#title", "028479", "Enap 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I10", "Esencialna hipertenzija", "http://www.cbz.si/cbz/bazazdr2.nsf/o/68FDAEEE845A0E52C12579C2003F563B/$File/a-016414.pdf", "059064", "Olivin 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I11", "Hipertenzivna srčna bolezen z (zastojno) srčno odpovedjo", "http://si.draagle.com/#!/drug/kzk/?sub=10", "011444", "Concor 5 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I11", "Hipertenzivna srčna bolezen z (zastojno) srčno odpovedjo", "http://www.lek.si/si/zdravila/na-recept/pakiranje/5862/", "115746", "Byol 5 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I11", "Hipertenzivna srčna bolezen z (zastojno) srčno odpovedjo", "http://www.cbz.si/cbz/bazazdr2.nsf/o/C393D32B6CCD5421C12579EC00200928/$File/a-009508.pdf", "129607", "Borez 5 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I11", "Hipertenzivna srčna bolezen z (zastojno) srčno odpovedjo", "http://www.cbz.si/cbz/bazazdr2.nsf/o/65930B0D5833253BC1257C780004AF95/$File/a-013730.pdf", "146097", "Concordina 5 mg / 5 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I11", "Hipertenzivna srčna bolezen z (zastojno) srčno odpovedjo", "http://www.cbz.si/cbz/bazazdr2.nsf/o/73A663A39EB07033C12579C2003F5EE2/$File/a-014615.pdf", "060755", "Lodoz 5 mg / 6,25 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I11", "Hipertenzivna srčna bolezen z (zastojno) srčno odpovedjo", "http://www.cbz.si/cbz/bazazdr2.nsf/o/06C4EB4CE17A2068C1257C780004B023/$File/a-013839.pdf", "146144", "Sobycor 5 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E11", "Diabetes tip 2", "http://www.medis.si/fileadmin/medis/medis.si/docs/Navodilo_za_uporabo_Aglurab_SI.pdf", "144343", "Aglurab 1000 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E11", "Diabetes tip 2", "http://si.draagle.com/#!/greader/?file=http%3A%2F%2Fskrito.draagle.com%2Fmedia%2Fd%2Fpil%2F040886_pil.pdf", "040886", "Glucophage 1000 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E11", "Diabetes tip 2", "https://mediately.co/si/drugs/WjSUunNJrYrsXmP7DiMg2FANnb9/belformin-500-mg-filmsko-oblozene-tablete", "145137", "Belformin 500 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E11", "Diabetes tip 2", "http://www.cbz.si/cbz/bazazdr2.nsf/o/C35AF3CC02742C17C12579EC0020018C/$File/a-007344.pdf", "108375", "Formagliben 500 mg / 2,5 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E11", "Diabetes tip 2", "http://www.cbz.si/cbz/bazazdr2.nsf/o/2482BE471CABFF87C12579C2003F5360/$File/a-015772.pdf", "040886", "Glucophage 1000 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E11", "Diabetes tip 2", "http://www.cbz.si/cbz/bazazdr2.nsf/o/4FC2A54BA1DBA6A0C12579C2003F6956/$File/a-020018.pdf", "042021", "Metfogamma 1000 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E11", "Diabetes tip 2", "http://www.cbz.si/cbz/bazazdr2.nsf/o/1D5A54DC62638DE6C12579C2003F61CD/$File/a-014628.pdf", "025550", "Siofor 1000 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E10", "Diabetes tip 1", "https://www.diagnosia.com/si/zdravila/actrapid-100-ieml-raztopina-za-injiciranje-v-viali", "030619", "Actrapid 100 i.e.Raztopina za injiciranje v viali");
            AddOrUpdateDiseaseMedications(context, "E10", "Diabetes tip 1", "https://www.diagnosia.com/si/zdravila/actrapid-flexpen-100-ieml-raztopina-za-injiciranje-v-napolnjenem-injekcijskem-peresniku", "051101", "Actrapid FlexPen 100 i.e.Raztopina za injiciranje v napolnjenem injekcijskem peresniku");
            AddOrUpdateDiseaseMedications(context, "E10", "Diabetes tip 1", "http://www.cbz.si/cbz/bazazdr2.nsf/o/5536585C91748BDFC12579C2003F5D63/$File/a-012384.pdf", "095990", "Humulin M3 100 i.e./ ml suspenzija za injiciranje v vložku");
            AddOrUpdateDiseaseMedications(context, "E10", "Diabetes tip 1", "https://myhealthbox.eu/fr/view/1697664/a841ce6cfa958e9d21d2636b18e07e8c/leaflet", "030147", "Insuman Rapid 100 i.e./ ml OptiSet raztopina za injiciranje");
            AddOrUpdateDiseaseMedications(context, "E10", "Diabetes tip 1", "http://www.diagnosia.com/si/zdravila/mixtard-30-novolet-100-ieml-suspenzija-za-injiciranje-v-napolnjenem-injekcijskem-peresniku", "019534", "Mixtard 10 NovoLet 100 i.e./ ml suspenzija za injiciranje v napolnjenem injekcijskem peresniku");
            AddOrUpdateDiseaseMedications(context, "K29", "Gastritis", "http://www.cbz.si/cbz/bazazdr2.nsf/o/C3E218A9243FF5E9C1257C310004BB75?opendocument", "145976", "Ranitidin Accord 150 mg tbl");
            AddOrUpdateDiseaseMedications(context, "K29", "Gastritis", "http://www.lek.si/si/zdravila/brez-recepta/ranital-s-150/", "071684", "Ranital 150 mg tbl");
            AddOrUpdateDiseaseMedications(context, "R10.0", "Bolečina v trebuhu ali medenici", "http://www.cbz.si/cbz/bazazdr2.nsf/o/017078003F4E9B32C1257CC90083116E/$File/a-014247.pdf", "146311", "Metamizol STADA 500 mg / ml peroralne kapljice, raztopina");
            AddOrUpdateDiseaseMedications(context, "R10.0", "Bolečina v trebuhu ali medenici", "http://data.zdravila.net/pdf/a-010513.pdf", "000191", "Analgin 500 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N40", "Hiperplazija prostate", "http://www.cbz.si/cbz/bazazdr2.nsf/o/7C3C54F51BD29C59C12579C2003F63EF?opendocument", "038695", "Omnic Ocas 0,4 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N40", "Hiperplazija prostate", "http://si.draagle.com/#!/greader/?file=http%3A%2F%2Fskrito.draagle.com%2Fmedia%2Fd%2Fpil%2F105864_pil.pdf", "105864", "Combodart 0,5 mg / 0,4mg kaps");
            AddOrUpdateDiseaseMedications(context, "N40", "Hiperplazija prostate", "http://www.cbz.si/cbz/bazazdr2.nsf/o/374B2D55A7D6E43AC12579EC002008A5/$File/a-016035.pdf", "128333", "Miktan 0,4 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N40", "Hiperplazija prostate", "http://www.cbz.si/cbz/bazazdr2.nsf/o/CD18459F93237B13C12579C2003F68AF/$File/a-015652.pdf", "033880", "Morvesin 0,4 mg trde kapsule");
            AddOrUpdateDiseaseMedications(context, "N40", "Hiperplazija prostate", "http://www.cbz.si/cbz/bazazdr2.nsf/o/B940B7C0F083BE58C12579C2003F637A/$File/a-015072.pdf", "038245", "Tanyz 0,4 mg trde kapsule");
            AddOrUpdateDiseaseMedications(context, "E03", "Hipotiroza (druge vrste)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/3291459E7EB4AD14C1257CB400833420?opendocument", "146102", "Dicitirox 50 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E03", "Hipotiroza (druge vrste)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/2ABD62F024313965C12579C2003F5CBB/$File/a-012092.pdf", "092010", "Eltroxin 50 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E03", "Hipotiroza (druge vrste)", "http://si.draagle.com/#!/source/ljn/?drug=ljo", "023442", "Euthyrox 50 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N30", "Cistitis (vnetja sečnega mehurja)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/6151BEF7B09CA95AC12579C2003F5062?opendocument", "022454", "Ciprobay 500 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N30", "Cistitis (vnetja sečnega mehurja)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/44DDA83404E35C16C12579C2003F533A/$File/a-015920.pdf", "040398", "Ciprinol 500 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N30", "Cistitis (vnetja sečnega mehurja)", "http://www.lek.si/si/zdravila/na-recept/pakiranje/1692/", "086029", "Ciprofloksacin Lek 500 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N30", "Cistitis (vnetja sečnega mehurja)", "http://www.lek.si/si/zdravila/na-recept/pakiranje/433/", "069418", "Primotren 80mg / 400 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E78.0", "Hiperholesterolemija", "http://www.cbz.si/cbz/bazazdr2.nsf/o/F52A113BA34EB9E3C12579EC00200024?opendocument", "104426", "Coupet 20 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E78.0", "Hiperholesterolemija", "http://www.krka.si/sl/zdravila-in-izdelki/zdravila-na-recept/sorvastatablete/1673/", "109827", "Sorvasta 20 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E78.0", "Hiperholesterolemija", "http://www.cbz.si/cbz/bazazdr2.nsf/o/EBA7391D45C8FEBDC12579EC0020021A/$File/a-014601.pdf", "109932", "Vosustat 20 mg tbl");
            AddOrUpdateDiseaseMedications(context, "E78.0", "Hiperholesterolemija", "http://www.cbz.si/cbz/bazazdr2.nsf/o/A2118DFEC432DB52C12579EC00200204/$File/a-016289.pdf", "109690", "Rosuvastatin Teva 20 mg tbl");
            AddOrUpdateDiseaseMedications(context, "J11", "Gripa, virus ni dokazan", "http://www.cbz.si/cbz/bazazdr2.nsf/o/1B374BA216FAD256C12579C2003F6932?opendocument", "034487", "Daleron 500 mg tbl");
            AddOrUpdateDiseaseMedications(context, "J11", "Gripa, virus ni dokazan", "http://www.lek.si/si/zdravila/brez-recepta/lekadol-filmsko-oblozene-tablete/", "055654", "Lekadol 500 mg tbl");
            AddOrUpdateDiseaseMedications(context, "J11", "Gripa, virus ni dokazan", "http://www.cbz.si/cbz/bazazdr2.nsf/o/74B2434C07A44F18C12579C2003F4B3E/$File/a-011568.pdf", "002739", "Calpol 250 mg / 5 ml peroralna suspenzija");
            AddOrUpdateDiseaseMedications(context, "J11", "Gripa, virus ni dokazan", "http://www.cbz.si/cbz/bazazdr2.nsf/o/8BA9838F72FB4FA4C12579EC001FFABB?opendocument", "072940", "Doreta 37,5 mg / 325 mg");
            AddOrUpdateDiseaseMedications(context, "J11", "Gripa, virus ni dokazan", "http://www.cbz.si/cbz/bazazdr2.nsf/o/4D14143C7F6E1F04C1257C620004CDD8/$File/a-016095.pdf", "146066", "Ibuem 250 mg / 250 mg / 50 mg tbl");
            AddOrUpdateDiseaseMedications(context, "J11", "Gripa, virus ni dokazan", "http://www.cbz.si/cbz/bazazdr2.nsf/o/97D3848355D4ABDAC12579C2003F5CDE/$File/a-015216.pdf", "093351", "Panadol 500 mg tbl");
            AddOrUpdateDiseaseMedications(context, "J11", "Gripa, virus ni dokazan", "http://www.cbz.si/cbz/bazazdr2.nsf/o/C8122F0572FA7141C12579EC001FFF17/$File/a-600695.pdf", "600695", "Paracetamol svečke 500 mg (Lekarne Ljubljana)");
            AddOrUpdateDiseaseMedications(context, "J11", "Gripa, virus ni dokazan", "http://www.cbz.si/cbz/bazazdr2.nsf/o/FCD99A29EDCF611EC12579F900492129/$File/a-016002.pdf", "136058", "Tevitamol 500 mg tablete");
            AddOrUpdateDiseaseMedications(context, "F41.0", "Panična anksiozna motnja", "http://www.cbz.si/cbz/bazazdr2.nsf/o/5C58B200098CB5A2C12579C2003F53E1?opendocument", "046124", "Lexaurin 3 mg tbl");
            AddOrUpdateDiseaseMedications(context, "F41.0", "Panična anksiozna motnja", "http://www.cbz.si/cbz/bazazdr2.nsf/o/1AF7CA6F1A775F6BC12579C2003F53C6/$File/a-015373.pdf", "045136", "Lekotam 3 mg tbl");
            AddOrUpdateDiseaseMedications(context, "F41.0", "Panična anksiozna motnja", "http://www.krka.si/sl/zdravila-in-izdelki/zdravila-na-recept/apaurintablete/1287/", "019348", "Apaurin 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "F32.1", "Zmerna depresivna motnja", "http://www.cbz.si/cbz/bazazdr2.nsf/o/0049AAE59E3AA8D3C12579C2003F532C?opendocument", "040096", "Cipralex 10 mg");
            AddOrUpdateDiseaseMedications(context, "F32.1", "Zmerna depresivna motnja", "http://www.lek.si/si/zdravila/na-recept/pakiranje/5775/", "125610", "Citafort 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "F32.1", "Zmerna depresivna motnja", "http://www.cbz.si/cbz/bazazdr2.nsf/o/8911B2FE3FFF0EF2C12579EC001FF931/$File/a-016214.pdf", "058793", "Ecytara 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "F32.1", "Zmerna depresivna motnja", "http://www.cbz.si/cbz/bazazdr2.nsf/o/A9B3E333AEC06FBEC12579EC001FFC93/$File/a-016422.pdf", "085685", "Elicea 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "F32.1", "Zmerna depresivna motnja", "http://www.cbz.si/cbz/bazazdr2.nsf/o/C0CAA315ECDB0887C1257CC90083113C/$File/a-016017.pdf", "146299", "Escitalopram Krka 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "F32.1", "Zmerna depresivna motnja", "http://www.cbz.si/cbz/bazazdr2.nsf/o/011783EE948D7D8FC12579EC00200501/$File/a-016059.pdf", "118460", "Otigem 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "F32.1", "Zmerna depresivna motnja", "http://www.cbz.si/cbz/bazazdr2.nsf/o/90DBE9EE574E4B0BC12579EC00200012/$File/a-016440.pdf", "104213", "Solatcit 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "S52.5", "Zlom spodnjega dela koželjnice Bolečine", "http://www.cbz.si/cbz/bazazdr2.nsf/o/8BA9838F72FB4FA4C12579EC001FFABB?opendocument", "072940", "Doreta 37,5 mg / 325 mg");
            AddOrUpdateDiseaseMedications(context, "S52.5", "Zlom spodnjega dela koželjnice Bolečine", "http://www.zdravila.net/navodilo.php?navodilo=s-005819.pdf&d", "012114", "Tramal 150 mg tbl");
            AddOrUpdateDiseaseMedications(context, "S52.5", "Zlom spodnjega dela koželjnice Bolečine", "http://www.cbz.si/cbz/bazazdr2.nsf/o/63B2B4273D302F22C12579C2003F4E25/$File/a-016266.pdf", "012084", "Tadol 100 mg tbl s podaljšanim sproščanjem");
            AddOrUpdateDiseaseMedications(context, "S52.5", "Zlom spodnjega dela koželjnice Bolečine", "http://www.cbz.si/cbz/bazazdr2.nsf/o/031488B8CE92CA7AC1257BAC0083438E/$File/a-014109.pdf", "145499", "Tramadol Vitabalans 50 mg tbl");
            AddOrUpdateDiseaseMedications(context, "S52.5", "Zlom spodnjega dela koželjnice Bolečine", "http://www.cbz.si/cbz/bazazdr2.nsf/o/871247132BF7287FC12579EC0020072B/$File/a-011732.pdf", "124680", "Zaracet 37,5 mg / 325 mg tbl");
            AddOrUpdateDiseaseMedications(context, "J30.1", "Alergijski rinitis zaradi peloda", "http://www.cbz.si/cbz/bazazdr2.nsf/o/85571397365F09F1C12579EC001FF803?opendocument", "020583", "Flonidan 10 mg");
            AddOrUpdateDiseaseMedications(context, "J30.1", "Alergijski rinitis zaradi peloda", "http://www.lekarnar.com/izdelki/claritine-s-tablete", "062987", "Claritine S 10 mg tbl");
            AddOrUpdateDiseaseMedications(context, "J30.1", "Alergijski rinitis zaradi peloda", "http://www.cbz.si/cbz/bazazdr2.nsf/o/DA55403BA60DE053C12579EC001FF806/$File/a-013832.pdf", "051420", "Florgan 10 mg orodisperzibilne tbl");
            AddOrUpdateDiseaseMedications(context, "J30.1", "Alergijski rinitis zaradi peloda", "https://www.lekarna24ur.com/public/upload/dokumenti/Rinolan_navodilo_pdf.pdf", "058238", "Rinolan 10 mg tablete");
            AddOrUpdateDiseaseMedications(context, "H40", "Glavkom", "http://www.cbz.si/cbz/bazazdr2.nsf/o/A3DFEF2F17A035ACC1257D1600831212?opendocument", "146530", "Bimatoprost Sandoz 0,3 mg / ml kapljice");
            AddOrUpdateDiseaseMedications(context, "H40", "Glavkom", "https://www.diagnosia.com/si/zdravila/lumigan-01-mgml-kapljice-za-oko-raztopina", "102229", "Lumigan 0,1 mg / ml kapljice");
            AddOrUpdateDiseaseMedications(context, "H40", "Glavkom", "http://www.cbz.si/cbz/bazazdr2.nsf/o/727DB8859728BBDEC12579F90049223E/$File/a-016139.pdf", "139603", "Brimonidin Medops 2 mg / ml kapljice za oko");
            AddOrUpdateDiseaseMedications(context, "H40", "Glavkom", "http://www.cbz.si/cbz/bazazdr2.nsf/o/86C91BB4FE577DACC12579EC00200369/$File/a-014453.pdf", "114022", "Timalen 2,5 mg / ml kapljice za oko, raztopina");
            AddOrUpdateDiseaseMedications(context, "H40", "Glavkom", "http://www.cbz.si/cbz/bazazdr2.nsf/o/159103D546E2C185C12579EC00200367/$File/a-020005.pdf", "114006", "Latanox 50 mg / ml kapljice za oko");
            AddOrUpdateDiseaseMedications(context, "H65.0", "Akutno serozno vnetje srednjega ušesa", "http://www.cbz.si/cbz/bazazdr2.nsf/o/2F6CCCC907EB6078C12579C2003F514E?opendocument", "025666", "Hiconcil 500 mg trde kapsule");
            AddOrUpdateDiseaseMedications(context, "H65.0", "Akutno serozno vnetje srednjega ušesa", "http://www.lek.si/si/zdravila/na-recept/pakiranje/89/", "069280", "Amoksiklav 500mg / 125mg tbl");
            AddOrUpdateDiseaseMedications(context, "H65.0", "Akutno serozno vnetje srednjega ušesa", "http://www.cbz.si/cbz/bazazdr2.nsf/o/1FFC4EAA3F7319EEC1257EAB00837141/$File/a-015915.pdf", "147056", "Betaklav 500 mg / 125 mg tbl");
            AddOrUpdateDiseaseMedications(context, "H65.0", "Akutno serozno vnetje srednjega ušesa", "http://www.cbz.si/cbz/bazazdr2.nsf/o/1C2B687B0E1FB855C12579C2003F6948/$File/a-016157.pdf", "041866", "Ospamox 500 mg disperzibilne tbl");
            AddOrUpdateDiseaseMedications(context, "I35.0", "Aortna (valvularna) stenoza", "http://www.cbz.si/cbz/bazazdr2.nsf/o/582412352E8F356CC12579C2003F58F2?opendocument", "072656", "Lasix 40 mg tbl");
            AddOrUpdateDiseaseMedications(context, "I35.0", "Aortna (valvularna) stenoza", "http://www.lek.si/si/zdravila/na-recept/pakiranje/198/", "026778", "Edemid 40 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N48.4", "Impotenca organskega izvora", "http://www.cbz.si/cbz/bazazdr2.nsf/o/C78700915441F103C12579EC002001C7?opendocument", "108995", "Belfil 50 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N48.4", "Impotenca organskega izvora", "https://www.diagnosia.com/si/zdravila/sildenafil-teva-100-mg-filmsko-oblozene-tablete", "097420", "Sildenafil Teva 100 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N48.4", "Impotenca organskega izvora", "http://www.cbz.si/cbz/bazazdr2.nsf/o/396405FCEAF6D06DC12579EC001FFD67/$File/a-014664.pdf", "091782", "Tornetis 100 mg tbl");
            AddOrUpdateDiseaseMedications(context, "N48.4", "Impotenca organskega izvora", "https://www.diagnosia.com/si/zdravila/viagra-50-mg-filmsko-oblozene-tablete", "093564", "Viagra 50 mg tbl");
            AddOrUpdateDiseaseMedications(context, "K21", "Gastroezofagealna refluksna bolezen (GERB)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/16D4CBF7CC46F980C12579C2003F67F1/$File/a-016396.pdf", "028622", "Acipan 20 mg gastrorezistentne tbl");
            AddOrUpdateDiseaseMedications(context, "K21", "Gastroezofagealna refluksna bolezen (GERB)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/C780D3BD9FE393DAC12579C2003F50BD/$File/a-015817.pdf", "023507", "Controloc 20 mg gastrorezistentne tbl");
            AddOrUpdateDiseaseMedications(context, "K21", "Gastroezofagealna refluksna bolezen (GERB)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/520C2C9888BDDC6CC12579C2003F6677/$File/a-016474.pdf", "013200", "Nolpaza 20 mg gastrorezistentne tbl");
            AddOrUpdateDiseaseMedications(context, "K21", "Gastroezofagealna refluksna bolezen (GERB)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/33C7A15D9E906947C12579C2003F4EB7/$File/a-015564.pdf", "013730", "Nexium 20 mg gastrorezistentne tbl");
            AddOrUpdateDiseaseMedications(context, "K21", "Gastroezofagealna refluksna bolezen (GERB)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/5C09B9EE0916EEB2C12579C2003F58AF/$File/a-016031.pdf", "071684", "Ranital 150 mg tbl");
            AddOrUpdateDiseaseMedications(context, "K21", "Gastroezofagealna refluksna bolezen (GERB)", "http://www.cbz.si/cbz/bazazdr2.nsf/o/AE0A1FEA862CC338C12579C2003F5986/$File/a-014527.pdf", "075566", "Rupurut 500 mg žvečljive tbl");
            AddOrUpdateDiseaseMedications(context, "K25", "Razjeda na želodcu", "http://www.cbz.si/cbz/bazazdr2.nsf/o/16D4CBF7CC46F980C12579C2003F67F1/$File/a-016396.pdf", "028622", "Acipan 20 mg gastrorezistentne tbl");
            AddOrUpdateDiseaseMedications(context, "K25", "Razjeda na želodcu", "http://www.cbz.si/cbz/bazazdr2.nsf/o/C780D3BD9FE393DAC12579C2003F50BD/$File/a-015817.pdf", "023507", "Controloc 20 mg gastrorezistentne tbl");
            AddOrUpdateDiseaseMedications(context, "K25", "Razjeda na želodcu", "http://www.cbz.si/cbz/bazazdr2.nsf/o/520C2C9888BDDC6CC12579C2003F6677/$File/a-016474.pdf", "013200", "Nolpaza 20 mg gastrorezistentne tbl");
            AddOrUpdateDiseaseMedications(context, "K25", "Razjeda na želodcu", "http://www.cbz.si/cbz/bazazdr2.nsf/o/33C7A15D9E906947C12579C2003F4EB7/$File/a-015564.pdf", "013730", "Nexium 20 mg gastrorezistentne tbl");
            AddOrUpdateDiseaseMedications(context, "K25", "Razjeda na želodcu", "http://www.cbz.si/cbz/bazazdr2.nsf/o/AE0A1FEA862CC338C12579C2003F5986/$File/a-014527.pdf", "075566", "Rupurut 500 mg žvečljive tbl");
            AddOrUpdateDiseaseMedications(context, "C91", "Limfatična levkemija", "http://rxed.eu/sl/g/Glivec/5/", "080608", "Glivec 100 mg tbl");
            AddOrUpdateDiseaseMedications(context, "C91", "Limfatična levkemija", "http://rxed.eu/sl/i/Imatinib+Teva/5/", "145204", "Imatinib Teva 100 mg tbl");
            AddOrUpdateDiseaseMedications(context, "C91", "Limfatična levkemija", "http://www.cbz.si/cbz/bazazdr2.nsf/o/9F5DD2DFF700BFEDC1257B4B00836C1C/$File/a-013808.pdf", "145415", "Meaxin 100 mg tbl");
            AddOrUpdateDiseaseMedications(context, "C92", "Mieloična levkemija", "http://rxed.eu/sl/i/Imatinib+Teva/5/", "145204", "Imatinib Teva 100 mg tbl");
            AddOrUpdateDiseaseMedications(context, "C92", "Mieloična levkemija", "http://www.cbz.si/cbz/bazazdr2.nsf/o/9F5DD2DFF700BFEDC1257B4B00836C1C/$File/a-013808.pdf", "145415", "Meaxin 100 mg tbl");
            AddOrUpdateDiseaseMedications(context, "C92", "Mieloična levkemija", "http://rxed.eu/sl/g/Glivec/5/", "080608", "Glivec 100 mg tbl");

            //Take from SifrantiIzUcilnice/Pregled sifrantov
            context.Allergies.AddOrUpdate(k => k.AllergyKey,
              new Allergy { AllergyKey = "D69.0", AllergyName = "Alergijska purpura" },
              new Allergy { AllergyKey = "J30.1", AllergyName = "Alergijsi rinitis zaradi peloda" },
              new Allergy { AllergyKey = "J45.0", AllergyName = "Pretežno alergijska astma " },
              new Allergy { AllergyKey = "K52.2", AllergyName = "Alergijske in dietetični gastroenteritis in kolitis" },
              new Allergy { AllergyKey = "L23", AllergyName = "Alergijski konatktni dermatitis" },
              new Allergy { AllergyKey = "L50.0", AllergyName = "Preobčutljivostna koprivnica (alergijska urtikarija)" },
              new Allergy { AllergyKey = "T78.4", AllergyName = "Alergija, neopredeljena" },
              new Allergy { AllergyKey = "Z88.0", AllergyName = "Osebna anamneza alergije na penicilin" });

            AddOrUpdateDietInstructions(context, "D001", "Dieta pri celiakiji", "http://www.drustvo-celiakija.si/celiakija");
            AddOrUpdateDietInstructions(context, "D002", "Dieta za ledvične bolnike", "http://www.zveza-dlbs.si/Prehrana.html");
            AddOrUpdateDietInstructions(context, "D003", "Dieta pri refluksni bolezni", "http://www.kclj.si/dokumenti/000203-0002f9.pdf");
            AddOrUpdateDietInstructions(context, "D004", "Dieta za sladkorne bolnike", "http://www.diabetes-zveza.si/uploads/SB95_julij12clanki1.pdf");
            AddOrUpdateDietInstructions(context, "D004", "Dieta za sladkorne bolnike", "http://www.ezdravje.com/srce-in-zilje/druge-bolezni-srca-in-zilja/sladkorna-bolezen/?s=9");
            AddOrUpdateDietInstructions(context, "D004", "Dieta za sladkorne bolnike", "http://www.sladkorcki.si/media/docs/Prehrana_pri_SB.pdf");
            AddOrUpdateDietInstructions(context, "D005", "Dieta za znižanje holesterola", "http://www.lek.si/si/skrb-za-zdravje/bolezni-in-simptomi/srce-ozilje/diete-holesterol/");
            AddOrUpdateDietInstructions(context, "D005", "Dieta za znižanje holesterola", "http://www.krka.si/media/prk/dokumenti/0577_dieta_ob_povisanem_holesterolu.pdf");
            AddOrUpdateDietInstructions(context, "D006", "Prehrana pri driski", "http://www.nasa-lekarna.si/clanki/clanek/skuhaj-olupi-ali-pusti/");
            AddOrUpdateDietInstructions(context, "D006", "Prehrana pri driski", "http://www.dolenjske-lekarne.si/novice/samozdravljenje-driske");
            AddOrUpdateDietInstructions(context, "D007", "Dieta za znižanje trigliceridov", "http://www.ave.si/novice/prehrana-pri-povisanih-trigliceridih");
            AddOrUpdateDietInstructions(context, "D008", "Dieta pri boleznih jeter", "http://www.kclj.si/dokumenti/000203-0002fe.pdf");
            AddOrUpdateDietInstructions(context, "D009", "Dieta pri boleznih želodca in dvanajstnika", "http://www.kclj.si/dokumenti/000203-0002f6.pdf");

            Measurement mes = new Measurement { MeasurementName = "Glukoza", MeasurementNotes = "" };
            AddOrUpdateMeasurement(context,
                mes,
                "Sladkor v krvi",
                "7 na dan",
                "mmol/l",
                "pred in po obrokih in pred spanjem",
                //"4,0 in 6,0 ",
                //"Hipoglikemija so vrednosti pod 4,0. Hipoglikemija ni bolezen temveč akutno stanje",
                //"Meritve za sladkorno bolezen so večje od 6,0, pogosto okoli 12,0",
                //"Neverjetne vrednosti so pod 0,0 ali nad 50,0"
                0,
                50,
                4,
                6
            );

            mes = new Measurement { MeasurementName = "Krvni pritisk", MeasurementNotes = "" };
            AddOrUpdateMeasurement(context,
                mes,
                "Sistolični tlak",
                "2 na dan",
                "mmHg",
                "zjutraj in zvečer",
                //"100 – 135",
                //"Hipotenzija so vrednosti pod ali 90",
                //"Hipertenzija so vrednosti nad ali 140",
                //"pod 30, ali nad 300"
                30,
                300,
                100,
                135
            );
            AddOrUpdateMeasurement(context,
                mes,
                "Diastolični tlak",
                "2 na dan",
                "mmHg",
                "zjutraj in zvečer",
                //"60 – 85",
                //"Hipotenzija so vrednosti pod ali 60",
                //"Hipertenzija so vrednosti nad ali 90",
                //"pod 30, ali nad 300"
                30,
                300,
                60,
                85
            );

            mes = new Measurement { MeasurementName = "Srčni utrip", MeasurementNotes = "Meri se skupaj z pritiskom." };
            AddOrUpdateMeasurement(context,
                mes,
                "Število udarcev srca",
                "2 na dan",
                "udarcev/min",
                "zjutraj in zvečer",
                //"od 60 do 100",
                //"Bradikardija so meritve pod 60",
                //"Tahikardija so meritve nad 100",
                //"pod 30, ali nad 200"
                30,
                200,
                60,
                100
            );

            mes = new Measurement { MeasurementName = "Telesna temperatura", MeasurementNotes = "" };
            AddOrUpdateMeasurement(context,
                mes,
                "Telesna temperatura",
                "2-3 na dan",
                "°C",
                "Kadarkoli na dan",
                //"od 35,5 do 37,4",
                //"Hipotermija so meritve pod 35,5",
                //"Hipertermija so meritve nad 37,5",
                //"pod 34, ali nad 42"
                34,
                42,
                35.5,
                37.4
            );

            mes = new Measurement { MeasurementName = "Teža", MeasurementNotes = "" };
            AddOrUpdateMeasurement(context,
                mes,
                "Telesna teža",
                "1 krat na teden",
                "kg",
                "Kadarkoli v tednu",
                //"vrednosti indeksa telesne mase 21-24 BMI (body mass index) ",
                //"Podhranjenost so BMI vrednosti pod 20 ",
                //"Prekomerna teža so BMI vrednosti nad 24",
                //"Neverjetne vrednosti so BMI vrednosti pod 15, ali nad 50"
                0,
                1000,
                40,
                90
            );

            #endregion

            AddOrUpdateApplicationUser(context, "matjaz.mav@tpo10.com", "matjazmav1", nameof(Administrator));
            AddOrUpdateApplicationUser(context, "admin@tpo10.com", "geslo123", nameof(Administrator));

            AddOrUpdateApplicationUser(context, "doctor1@tpo10.com", "geslo123", nameof(Doctor));
            AddOrUpdateApplicationUser(context, "doctor2@tpo10.com", "geslo123", nameof(Doctor));
            AddOrUpdateApplicationUser(context, "doctor3@tpo10.com", "geslo123", nameof(Doctor));
            AddOrUpdateApplicationUser(context, "doctor4@tpo10.com", "geslo123", nameof(Doctor));

            context.SaveChanges();

            //context, key, Fname, Lname, phone, patient#, HCprovider, doc(0)/dentist(1), email
            AddDoctorProfile(context, "1111", "Primož", "Trubar", "11111111", 10, "00016", 0, "doctor1@tpo10.com");
            AddDoctorProfile(context, "2222", "Adam", "Bohorič", "222222222", 0, "00016", 0, "doctor2@tpo10.com");
            
            AddDoctorProfile(context, "3333", "France", "Prešeren", "333333333", 10, "00016", 1, "doctor3@tpo10.com");
            AddDoctorProfile(context, "4444", "Ivan", "Cankar", "444444444", 0, "00016", 1, "doctor4@tpo10.com");

            context.SaveChanges();
          
            var doctor1 = context.Users.FirstOrDefault(e => e.Email == "doctor1@tpo10.com") as Doctor;
            var doctor2 = context.Users.FirstOrDefault(e => e.Email == "doctor2@tpo10.com") as Doctor;

            // Add appointments
            for (int i = 0; i < 14; i++)
            {
                Appointment appointment = new Appointment()
                {
                    DoctorProfile = doctor1.DoctorProfile,
                    StartDateTime = DateTime.Now.AddHours(1*i),
                    EndDateTime = DateTime.Now.AddHours(1*i + 0.75),
                    Notes = "Prosti termin " + (i+1).ToString(),
                    IsAvailable = true
                };

                Appointment appointment2 = new Appointment()
                {
                    DoctorProfile = doctor2.DoctorProfile,
                    StartDateTime = DateTime.Now.AddDays(1).AddHours(1 * i),
                    EndDateTime = DateTime.Now.AddDays(1).AddHours(1 * i + 0.75),
                    Notes = "Prosti termin " + (i + 1).ToString(),
                    IsAvailable = true
                };

                context.Appointments.AddOrUpdate(appointment);
                context.Appointments.AddOrUpdate(appointment2);
                context.SaveChanges();

            }
            

            
        

#endif
        }

        private void AddOrUpdateApplicationUser(ApplicationDbContext context, string email, string password, string role)
        {

             using (var userStore = new UserStore<ApplicationUser>(context) { AutoSaveChanges = true }) 
             using (var userManager = new UserManager<ApplicationUser>(userStore)) 
             { 
                 var user = userManager.FindByEmail(email);
                if (user == null) 
                 {
                    switch (role)
                    {
                        case nameof(Administrator): user = new Administrator { UserName = email, Email = email }; break;
                        case nameof(Doctor): user = new Doctor { UserName = email, Email = email }; break;
                        case nameof(Nurse): user = new Nurse { UserName = email, Email = email }; break;
                        case nameof(Patient): user = new Patient { UserName = email, Email = email }; break;
                        default: user = new Patient { UserName = email, Email = email }; break;
                    }
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = true;
                    user.CreatedOn = DateTime.UtcNow;

                    userManager.Create(user, password); 
                    userManager.AddToRole(user.Id, role);
                } 
             } 
        }
        private void AddDoctorProfile(ApplicationDbContext context, string Key, string FirstName, string LastName, string Telephone, int PatientNumber, string HealthCareProviderNumber, int DocOrDentist, string email)
        {
            
            HealthCareProvider health = context.HealthCareProviders.FirstOrDefault(e => e.Key == HealthCareProviderNumber);
            var user = context.Users.FirstOrDefault(e => e.Email == email) as Doctor;

            if (health != null && user != null && !(context.Profiles.OfType<NurseProfile>().Any(e => e.NurseKey == Key) || context.Profiles.OfType<DoctorProfile>().Any(e => e.DoctorKey == Key)))
            {

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var docProfile = new DoctorProfile
                        {
                            DoctorKey = Key,
                            FirstName = FirstName,
                            LastName = LastName,
                            Telephone = Telephone,
                            PatientNumber = PatientNumber,
                            DocOrDentist = DocOrDentist,
                            CurrentPatientNumber = 0,
                            HealthCareProvider = health
                        };

                        context.Profiles.Add(docProfile);
                        context.SaveChanges();

                        user.DoctorProfile = docProfile;
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        #region Sprint3 AddOrUpdate methods for newly added entities.

        private void AddOrUpdateDiseaseMedications(ApplicationDbContext context, string diseaseKey, string diseaseName, string urlInstruction, string medicationKey, string medicationName)
        {

            Disease dis = context.Diseases.FirstOrDefault(p => p.DiseaseKey == diseaseKey);

            if (dis == null)
            {
                dis = new Disease { DiseaseKey = diseaseKey, DiseaseName = diseaseName };
            }
            MedicationInstruction ins = context.MedicationInstructions.FirstOrDefault(p=> p.Url == urlInstruction);
            if (ins == null)
            {
                ins = new MedicationInstruction { Url = urlInstruction }; 
            }

            var medication = context.Medications.FirstOrDefault(p => p.MedicationKey == medicationKey);
            if (medication == null)
            {
                medication = new Medication { MedicationKey = medicationKey, MedicationName = medicationName, MedicationInstruction = ins };
            }

            dis.Medications.Add(medication);
            context.Diseases.AddOrUpdate(dis);
            context.SaveChanges();
        }

        private void AddOrUpdateDietInstructions(ApplicationDbContext context, string dietKey, string dietName, string instructionUrl)
        {
            Diet diet = context.Diets.FirstOrDefault((p) => p.DietKey == dietKey);
            if (diet == null)
            {
                diet = new Diet { DietKey = dietKey, DietName = dietName };
                context.Diets.AddOrUpdate(diet);
            }

            DietInstruction ins = new DietInstruction { Diet = diet, Url = instructionUrl };
            context.DietInstructions.AddOrUpdate(k => k.Url, ins);
            context.SaveChanges();
        }

        private void AddOrUpdateMeasurement(ApplicationDbContext context, Measurement mes, string measurementPartName, string measurementPerDay, string measurementUnit, string measurementTime, /*string measurementNormal, string measurementBelow, string measurementMore, string measurementExtreme*/ double measurementMin, double measurementMax, double measurementNormalMin, double measurementNormalMax)
        {
            context.Measurements.AddOrUpdate(k => k.MeasurementName, mes);
            MeasurementPart part = new MeasurementPart
            {
                MeasurementPartName = measurementPartName,
                MeasurementTake = measurementPerDay,
                MeasurementUnit = measurementUnit,
                MeasurementTime = measurementTime,

                //MeasurementNormal = measurementNormal,
                // normal min
                //MeasurementBelow = measurementBelow,
                // normal max
                //MeasurementMore = measurementMore,
                // min and max
                //MeasurementExtreme = measurementExtreme,
                MeasurementMin = measurementMin,
                MeasurementMax = measurementMax,
                MeasurementNormalMin = measurementNormalMin,
                MeasurementNormalMax = measurementNormalMax,
                Measurement = mes
            };
            context.MeasurementParts.AddOrUpdate(k => k.MeasurementPartName, part);
            context.SaveChanges();
        }
        
        #endregion


    }
}
