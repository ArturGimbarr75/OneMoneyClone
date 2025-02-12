using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneMoneyCloneServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Decimals", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("02a94805-cd8a-6362-c147-e79e4f88cba9"), "MKD", 2, "Macedonian Denar", "den" },
                    { new Guid("030483f1-a13c-1859-73b9-752835a31c07"), "TZS", 2, "Tanzanian Shilling", "TSh" },
                    { new Guid("0a4231a1-7e53-1a6d-2523-079b0e28f991"), "GIP", 2, "Gibraltar Pound", "£" },
                    { new Guid("0c2207d4-a840-043c-a181-13629f23a763"), "GGP", 2, "Guernsey Pound", "£" },
                    { new Guid("0d956a48-d79a-dea3-d9f6-fe8a13803a97"), "TTD", 2, "Trinidad and Tobago Dollar", "TT$" },
                    { new Guid("0dd3fce2-1222-e0e6-a029-704038803f37"), "SYP", 2, "Syrian Pound", "LS" },
                    { new Guid("1289187c-d210-cdae-27ae-a1e09562a989"), "UYU", 2, "Uruguayan Peso", "$U" },
                    { new Guid("15127fd9-5505-772c-09f4-a998ebe7d84e"), "ZMW", 2, "Zambian Kwacha", "ZK" },
                    { new Guid("15656902-67e6-5096-baae-b843d97cafd7"), "PGK", 2, "Papua New Guinean Kina", "K" },
                    { new Guid("19c11074-e05c-e42f-5957-2628e9510004"), "GEL", 2, "Georgian Lari", "₾" },
                    { new Guid("1b522f66-c212-d240-c3c1-95f3df817b0c"), "IDR", 2, "Indonesian Rupiah", "Rp" },
                    { new Guid("1bd8d6bb-55fc-36c3-03ed-6378bc630669"), "JOD", 3, "Jordanian Dinar", "JD" },
                    { new Guid("1c7010ea-6905-a818-1dc8-9906b9019c35"), "XPF", 0, "CFP Franc (Franc Pacifique)", "₣" },
                    { new Guid("1d521a8c-1e10-4db2-139d-c9ddfa30002f"), "NPR", 2, "Nepalese Rupee", "Rs." },
                    { new Guid("1fdc9b26-aab1-c5dc-b575-a68220158602"), "SAR", 2, "Saudi Riyal", "SR" },
                    { new Guid("20758c97-14c5-0a1a-f188-f86e764e90da"), "AZN", 2, "Azerbaijani Manat", "ман" },
                    { new Guid("22d1a99d-f0fd-1d1b-b281-6592e00f28ad"), "NOK", 2, "Norwegian Krone", "kr" },
                    { new Guid("2339ec2f-a504-3ac2-c138-da22847f9b7c"), "PHP", 2, "Philippine Peso", "₱" },
                    { new Guid("23a6f372-126a-5fb7-033d-9a2529a3b875"), "AFN", 2, "Afghan Afghani", "Af" },
                    { new Guid("2428a728-cc03-1770-c9e1-d5d3f5041bfd"), "GHS", 2, "Ghanaian Cedi", "GH₵" },
                    { new Guid("264a68ea-3fe2-4a56-fb94-93fad725556e"), "ANG", 2, "Netherlands Antillean Guilder", "ƒ" },
                    { new Guid("285dfed9-f150-16ed-7451-b193e8bd0e0c"), "RON", 2, "Romanian Leu", "L" },
                    { new Guid("297a1d27-54c7-bdea-6a11-0781a1adbd2d"), "KWD", 3, "Kuwaiti Dinar", "KD" },
                    { new Guid("2a050d05-a326-9d10-0fb0-6176ee1db8e8"), "HKD", 2, "Hong Kong Dollar", "HK$" },
                    { new Guid("2a574ebe-f04e-cd45-c914-49b6c9435a8a"), "LAK", 2, "Lao Kip", "₭N" },
                    { new Guid("2b0ea592-0b3e-5ba4-28ab-150a385bafcc"), "GMD", 2, "Gambian Dalasi", "D" },
                    { new Guid("2b5655a0-59db-8bad-a9cc-680367308118"), "EUR", 2, "Euro", "€" },
                    { new Guid("2d96115b-e8cb-e55d-5770-d22d3e5fb85a"), "CUP", 2, "Cuban Peso", "$MN" },
                    { new Guid("2e05c22f-45aa-9a73-9fd0-854d4ed60178"), "CHF", 2, "Swiss Franc", "Fr." },
                    { new Guid("33e99e88-891f-9214-f89b-1e578fa377e0"), "CNY", 2, "Chinese Yuan", "CN¥" },
                    { new Guid("362ac415-3d05-4f89-ef1a-225ce99a3a2b"), "TMT", 2, "Turkmenistan Manat", "m." },
                    { new Guid("36a1cc65-7ef9-f628-ea8c-af95ba0be3d6"), "YER", 2, "Yemeni Rial", "YR" },
                    { new Guid("38a3c1b4-829b-a079-ee13-5fb1f8368255"), "ETB", 2, "Ethiopian Birr", "Br" },
                    { new Guid("39bdf548-263b-b98c-f43a-86af1a4d9e8c"), "UAH", 2, "Ukrainian Hryvnia", "₴" },
                    { new Guid("3bad9f41-82f0-1748-27a2-d47adce883a8"), "CUC", 2, "Cuban convertible Peso", "CUC$" },
                    { new Guid("3be039c5-b2e7-c869-a84f-85437bc8d298"), "BSD", 2, "Bahamian Dollar", "$" },
                    { new Guid("3e768d90-f1cf-0469-58ba-5863ae3b894f"), "PRB", 2, "Transnistrian Ruble", "р." },
                    { new Guid("3fb8df59-ac7c-3c4e-8ee9-1700ef2ad90d"), "TRY", 2, "Turkish Lira", "TL" },
                    { new Guid("3fcdf238-6be6-8a7b-64b4-6bc06880d4b7"), "BWP", 2, "Botswana Pula", "P" },
                    { new Guid("401229af-21e2-0ebb-94c2-f09ee87606cf"), "MOP", 2, "Macanese Pataca", "MOP$" },
                    { new Guid("40554325-f171-792b-a96a-c865112a53e0"), "HTG", 2, "Haitian Gourde", "G" },
                    { new Guid("4143af48-45f7-3f16-945f-a838eeabb062"), "AMD", 2, "Armenian Dram", "֏" },
                    { new Guid("4164005b-94e6-45cb-a1af-078e58a66a87"), "DKK", 2, "Danish Krone", "kr." },
                    { new Guid("4227f44f-52f9-693e-8b35-154f999f49a2"), "MNT", 2, "Mongolian Tögrög", "₮" },
                    { new Guid("43476567-32cc-eedf-bf2d-2d154db69cd8"), "RUB", 2, "Russian Ruble", "₽" },
                    { new Guid("44c6af00-1d9b-9ff3-464e-a2ca3e56af77"), "MMK", 2, "Myanmar Kyat", "Ks" },
                    { new Guid("457a12d5-3622-804c-5de5-104bb5503310"), "DJF", 2, "Djiboutian Franc", "Fdj" },
                    { new Guid("47321ae7-6977-c8ba-d129-a02cd467e3e6"), "LKR", 2, "Sri Lankan Rupee", "Rs." },
                    { new Guid("48c67697-6737-dacd-e0a3-8b6149c08539"), "KGS", 2, "Kyrgyzstani Som", "с" },
                    { new Guid("497cabbf-8f99-6358-fb8d-10c7f0ed8873"), "AUD", 2, "Australian Dollar", "AU$" },
                    { new Guid("4e6b6ab8-67b2-a95a-8b7a-63b568434502"), "SEK", 2, "Swedish Krona", "kr" },
                    { new Guid("4e913f2e-5a32-a01c-cb82-a132af1002d3"), "NZD", 2, "New Zealand Dollar", "NZ$" },
                    { new Guid("4fde0da3-c7fc-d1ac-174a-05337056b552"), "KES", 2, "Kenyan Shilling", "KSh" },
                    { new Guid("5010968a-0037-6def-0d6c-1caf8f04ed9f"), "MVR", 2, "Maldivian Rufiyaa", "MRf" },
                    { new Guid("508e79f7-53e5-34b2-27e7-df0a7a2652f5"), "CZK", 2, "Czech Koruna", "Kč" },
                    { new Guid("50c1f0d5-899f-17ff-8497-1832af4e7670"), "SLS", 2, "Somaliland Shilling", "Sl" },
                    { new Guid("53203a98-f729-bc7e-1712-be17806b8b0a"), "WST", 2, "Samoan Tala", "T" },
                    { new Guid("5409cbec-a9fc-00f2-5aea-084605df5ee9"), "CAD", 2, "Canadian Dollar", "CA$" },
                    { new Guid("5423cf5d-7420-563b-3642-2f69a2f7822c"), "VUV", 0, "Vanuatu Vatu", "VT" },
                    { new Guid("559286f0-9158-16e1-1c5a-ef5b2748d7cb"), "DOP", 2, "Dominican Peso", "RD$" },
                    { new Guid("55dcd9ca-ba10-12f0-abf9-02dfa6bd3ad0"), "SSP", 2, "South Sudanese Pound", "SS£" },
                    { new Guid("55f9b15f-5eb4-e338-1789-286a1790398d"), "ALL", 2, "Albanian Lek", "L" },
                    { new Guid("5a6da5a4-7482-44d7-b1ab-9678d60901bf"), "KID", 2, "Kiribati Dollar", "$" },
                    { new Guid("5b568650-0456-1b07-2d45-d42afcb0d3e9"), "NAD", 2, "Namibian Dollar", "N$" },
                    { new Guid("5d29220d-29ba-8a8b-4831-a943545b0810"), "JPY", 2, "Japanese Yen", "¥" },
                    { new Guid("5e7281f1-c8b3-2546-bc1c-77fa4b39f47c"), "JMD", 2, "Jamaican Dollar", "J$" },
                    { new Guid("5ff7ec50-7710-d2e1-50a7-81764b89cbc2"), "SGD", 2, "Singapore Dollar", "S$" },
                    { new Guid("60c073b8-2a92-f667-4ac0-9d27d1232f3a"), "HUF", 2, "Hungarian Forint", "Ft" },
                    { new Guid("67614275-c295-93eb-6397-1960a03be6d0"), "GTQ", 2, "Guatemalan Quetzal", "Q" },
                    { new Guid("678cf412-186c-e9ce-f424-d11554c49415"), "BZD", 2, "Belize Dollar", "BZ$" },
                    { new Guid("68f951a8-ddb8-06a6-535c-03efee304638"), "FJD", 2, "Fijian Dollar", "FJ$" },
                    { new Guid("6988531f-2c0f-c510-a68a-c0b28696fd8b"), "STN", 2, "Sao Tome and Príncipe Dobra", "Db" },
                    { new Guid("6a767c32-79c8-096b-f63d-a407c9c8967b"), "TND", 3, "Tunisian Dinar", "DT" },
                    { new Guid("6cb14b53-b3e9-e872-099d-b6081da2f962"), "KZT", 2, "Kazakhstani Tenge", "₸" },
                    { new Guid("6e156d15-a487-437a-5879-313a5ef39da4"), "VED", 2, "Venezuelan bolívar digital", "Bs." },
                    { new Guid("6f821189-ba30-9c98-56aa-38112064db7d"), "ZWL", 2, "Zimbabwean Dollar", "Z$" },
                    { new Guid("7441bca5-d568-c3c8-7867-2f6bdd2e0c90"), "HNL", 2, "Honduran Lempira", "L" },
                    { new Guid("744e6169-b041-9b1c-a6d4-974080d6d099"), "SDG", 2, "Sudanese Pound", "£SD" },
                    { new Guid("74b8c512-dd0b-9dc2-a376-7cf7aa684995"), "IQD", 3, "Iraqi Dinar", "د.ع." },
                    { new Guid("76e21711-52fc-c8e1-2ab6-7059d9ceca48"), "LYD", 3, "Libyan Dinar", "LD" },
                    { new Guid("770c05bb-8592-2f63-0e53-2eab4d629b1c"), "TWD", 2, "New Taiwan Dollar", "NT$" },
                    { new Guid("7b770567-2e71-11e8-e76f-b07162081d63"), "TOP", 2, "Tongan Paʻanga", "T$" },
                    { new Guid("7d2c2e91-b5f8-e9d7-63a9-cd82bf0f612f"), "CKD", 2, "Cook Islands Dollar", "$" },
                    { new Guid("7e312460-dd5b-62df-aa29-5395cbde54ab"), "SBD", 2, "Solomon Islands Dollar", "SI$" },
                    { new Guid("7eaaeee8-73e1-02b2-12e4-0babe414c5c0"), "ILS", 2, "Israeli new Shekel", "₪" },
                    { new Guid("7f8a7b1a-7e17-4e02-1685-e780c47649c6"), "BAM", 2, "Bosnia and Herzegovina Convertible Mark", "KM" },
                    { new Guid("820e7293-9d3d-f29a-3230-95152cb82906"), "MAD", 2, "Moroccan Dirham", "DH" },
                    { new Guid("8375f4dc-9f02-d679-4904-cf78daa360cb"), "PAB", 2, "Panamanian Balboa", "B/." },
                    { new Guid("845d4b1a-32a0-4a8c-33bd-669c608a34c3"), "CRC", 2, "Costa Rican Colon", "₡" },
                    { new Guid("8522dd3a-4f09-31dc-8690-2810080c1465"), "GBP", 2, "Pound Sterling", "£" },
                    { new Guid("865e727c-1a56-f1f1-b941-5bf0ea0679c9"), "BGN", 2, "Bulgarian Lev", "лв." },
                    { new Guid("86a6cb2d-72bf-6816-8c21-aaf78f409d11"), "MWK", 2, "Malawian Kwacha", "MK" },
                    { new Guid("8f676eb4-47c5-c84e-216c-5e3f4e9d327c"), "MYR", 2, "Malaysian Ringgit", "RM" },
                    { new Guid("926eca77-9f15-2b68-db43-52af6058eb92"), "GNF", 2, "Guinean Franc", "FG" },
                    { new Guid("94f81835-424d-2d21-d37d-affe097d216e"), "USD", 2, "United States Dollar", "$" },
                    { new Guid("98884324-53da-bf34-fffc-8ac71ad2bb4e"), "NGN", 2, "Nigerian Naira", "₦" },
                    { new Guid("991de080-b526-e74f-2941-0d78954faada"), "BBD", 2, "Barbadian Dollar", "BBD$" },
                    { new Guid("9954e1d1-d339-c1bd-caa1-0f65876dba6c"), "MRU", 0, "Mauritanian Ouguiya", "UM" },
                    { new Guid("9c6da159-d466-bf88-850d-7fb1e36c4e38"), "BTN", 2, "Bhutanese Ngultrum", "Nu." },
                    { new Guid("9cc1be6e-a3f0-09a6-354a-05acde9ca8af"), "IMP", 2, "Manx Pound", "£" },
                    { new Guid("9cd2c5bf-a278-f366-3479-d3fbad222d43"), "MZN", 2, "Mozambican Metical", "MTn" },
                    { new Guid("9ce1bd44-0ebc-0b83-caf0-54b5413dd39d"), "RSD", 2, "Serbian Dinar", "din" },
                    { new Guid("9ec98535-c765-76fb-b3a0-76723dc90c5f"), "FKP", 2, "Falkland Islands Pound", "FK£" },
                    { new Guid("9ecde9a9-ad81-da58-5b9a-608f70e1d7d9"), "XAF", 2, "Central African CFA Franc BEAC", "Fr" },
                    { new Guid("9f39b2f0-bfd4-d113-d6a8-e7bf52b27483"), "MUR", 2, "Mauritian Rupee", "Rs." },
                    { new Guid("a0093fc2-1d1b-f9d2-4308-1b0b6febaf99"), "KRW", 2, "South Korean Won", "₩" },
                    { new Guid("a03a80ff-17c5-da03-a2da-b2119613aa6f"), "ZAR", 2, "South African Rand", "R" },
                    { new Guid("a10a44f7-44ba-740f-555d-4c313c9b7677"), "SHP", 2, "Saint Helena Pound", "£" },
                    { new Guid("a34a0b1a-bb61-1553-e304-831a320f89b3"), "BRL", 2, "Brazilian Real", "R$" },
                    { new Guid("a41afad3-9f5b-6ee5-1fc1-b558d8ed6678"), "PEN", 2, "Peruvian Sol", "S/." },
                    { new Guid("a47b9428-0b75-c0ac-947b-e464145e08b0"), "KYD", 2, "Cayman Islands Dollar", "CI$" },
                    { new Guid("a5da4d34-06e9-0e91-af8b-8df4656a8551"), "ZWB", 0, "RTGS Dollar", "" },
                    { new Guid("a8318d34-a02f-20f4-fc0c-de4a1d0d845d"), "MDL", 2, "Moldovan Leu", "L" },
                    { new Guid("a83f0076-dba8-821c-36e0-ce931221b956"), "DZD", 2, "Algerian Dinar", "DA" },
                    { new Guid("a8afda91-e019-0ea0-fed5-b683ec81b9b2"), "VES", 2, "Venezuelan Bolívar Soberano", "Bs.F" },
                    { new Guid("a97206d9-bbf4-6a2b-a4dc-96ed2b419af0"), "TVD", 2, "Tuvaluan Dollar", "$" },
                    { new Guid("ac3f818d-37c4-8127-2b29-79fc265e4cad"), "SVC", 2, "Salvadoran Colón", "₡" },
                    { new Guid("ae5c7dce-0da4-e7f9-59a2-c1e0ec747f69"), "JEP", 2, "Jersey Pound", "£" },
                    { new Guid("af34431f-41e8-f7c3-6efb-f4f5504e9a0a"), "AOA", 2, "Angolan Kwanza", "Kz" },
                    { new Guid("affb8a7b-6a90-9670-01db-6e066a527dd1"), "UZS", 2, "Uzbekistani Som", "сум" },
                    { new Guid("b11bc376-a47a-c585-8620-656a77c13b11"), "BND", 2, "Brunei Dollar", "B$" },
                    { new Guid("b1507d3f-5e68-147b-f5bf-abf8b30c703a"), "ISK", 2, "Icelandic Krona", "kr" },
                    { new Guid("b356e5fe-69d1-2ebd-a6fb-e8e71f0ade0a"), "ERN", 2, "Eritrean Nakfa", "Nkf" },
                    { new Guid("b439a2fe-d174-b9a0-0401-6873d4f1ee24"), "TJS", 2, "Tajikistani Somoni", "SM" },
                    { new Guid("b9f73528-6807-e1ac-225a-7821f5bcd131"), "THB", 2, "Thai Baht", "฿" },
                    { new Guid("bb221ac1-7c55-feae-8a0f-3535dbf6d201"), "HRK", 2, "Croatian Kuna", "kn" },
                    { new Guid("bb3eb81a-8de5-8518-632b-175f762eb77a"), "BIF", 2, "Burundian Franc", "FBu" },
                    { new Guid("bdcf2eae-d495-dd75-f088-76080d57e3d9"), "SLL", 2, "Sierra Leonean Leone", "Le" },
                    { new Guid("bf3ae3b9-0846-74c4-1652-596350ea9718"), "QAR", 2, "Qatari Riyal", "QR" },
                    { new Guid("c04f60fd-b0da-9def-793c-9598ae881435"), "MXN", 2, "Mexican Peso", "MX$" },
                    { new Guid("c0dfd9b6-54fb-7327-21ce-bc0fff55df2f"), "NIO", 2, "Nicaraguan Córdoba", "C$" },
                    { new Guid("c1c5af97-029a-4c01-fde1-c064281437c5"), "COP", 2, "Colombian Peso", "CO$" },
                    { new Guid("c38bddf4-a29d-6b76-7408-d47a540aae25"), "EHP", 2, "Sahrawi Peseta", "Ptas." },
                    { new Guid("c8e8fa4f-bdc3-24a7-e6cc-853513870137"), "INR", 2, "Indian Rupee", "Rs." },
                    { new Guid("cbb16792-48c6-0e0d-a037-217688b3a655"), "PKR", 2, "Pakistani Rupee", "Rs." },
                    { new Guid("ce256ef1-ecc4-b3ca-e643-a66a8eccb1cb"), "VND", 2, "Vietnamese Dong", "₫" },
                    { new Guid("cf385935-b7e3-623a-4297-591972d27c01"), "BOB", 2, "Bolivian Boliviano", "Bs." },
                    { new Guid("cf6aa1ea-10a1-b24c-23a5-5fb03fdde12f"), "IRR", 2, "Iranian Rial", "﷼" },
                    { new Guid("cfda8d44-5193-1202-7e2c-6374c945725d"), "XCD", 2, "East Caribbean Dollar", "$" },
                    { new Guid("d0319b6f-b5ec-f704-dcc8-690d7c7840e1"), "PND", 2, "Pitcairn Islands Dollar", "$" },
                    { new Guid("d0b6ec83-0781-82a9-b9f7-495d3c265446"), "KPW", 2, "North Korean Won", "₩" },
                    { new Guid("d12a4f79-1e8c-bbd9-c158-1fe4589fba1b"), "BYN", 2, "Belarusian Ruble", "Br" },
                    { new Guid("d261eb65-f310-f4ec-45f5-12103e765526"), "KHR", 2, "Cambodian Riel", "៛" },
                    { new Guid("d3c63cb7-d3c1-f4fb-c49a-ea0b307498dd"), "CDF", 2, "Congolese Franc", "FC" },
                    { new Guid("d41f5c78-f550-26b4-27e7-9c1890076425"), "OMR", 3, "Omani Rial", "OR" },
                    { new Guid("d59cc2b9-3cf8-5b53-0bca-f31343315bad"), "SCR", 2, "Seychellois Rupee", "Rs." },
                    { new Guid("d6d95096-73d6-1255-28bb-1042f482459f"), "FOK", 2, "Faroese Króna", "kr" },
                    { new Guid("d8eed51b-a077-453f-eeb9-e0d518e4834a"), "PYG", 2, "Paraguayan Guaraní", "₲" },
                    { new Guid("df7be16e-7d4a-06a2-068f-e02847a4aed5"), "CVE", 2, "Cabo Verdean Escudo", "CV$" },
                    { new Guid("e185868b-8361-d093-0e8a-87328b75ddd6"), "GYD", 2, "Guyanese Dollar", "G$" },
                    { new Guid("e3366b73-b522-3659-97b4-927d6d9132ab"), "SZL", 2, "Swazi Lilangeni", "L" },
                    { new Guid("e504b448-b390-35e4-ec21-9a6f1cec68b4"), "BMD", 2, "Bermudian Dollar", "$" },
                    { new Guid("e59274d8-5375-83dd-4ebe-968ab2cc8107"), "BDT", 2, "Bangladeshi Taka", "৳" },
                    { new Guid("e5bf28d5-c9f0-ba92-ffcc-8a7bef5cdcfb"), "LRD", 2, "Liberian Dollar", "L$" },
                    { new Guid("e7f7d728-50bb-6ab4-f38d-9d150256df4e"), "AED", 2, "United Arab Emirates Dirham", "د.إ." },
                    { new Guid("e87ef008-3803-cfd2-4fd6-5e7bc1909085"), "KMF", 2, "Comorian Franc", "CF" },
                    { new Guid("ea876644-b12d-a7ad-5be5-ed053be77f59"), "PLN", 2, "Polish Zloty", "zł" },
                    { new Guid("eab80530-6fb9-df81-142d-787d501d0537"), "LSL", 2, "Lesotho Loti", "L" },
                    { new Guid("eb4e9cc2-372e-d597-e676-21f51f3aecc1"), "RWF", 2, "Rwandan Franc", "FRw" },
                    { new Guid("ed4e06a4-e091-a871-d451-e0d09b480f78"), "SRD", 2, "Surinamese Dollar", "Sr$" },
                    { new Guid("ede1d560-b630-558d-e6a1-8004b2d17ad2"), "SOS", 2, "Somali Shilling", "Sh.So." },
                    { new Guid("ee86f9f3-a4ad-f71a-77ef-5911d96c51ac"), "LBP", 2, "Lebanese Pound", "LL." },
                    { new Guid("f0f39460-5873-4369-5cdb-49c60235bffe"), "Abkhazia", 0, "Abkhazian Apsar", "" },
                    { new Guid("f293e3e4-f89a-c8aa-d614-354c3d5f3f4b"), "MGA", 0, "Malagasy Ariary", "Ar" },
                    { new Guid("f36e5a06-b4d8-3dcf-1bde-04d9705bebcc"), "AWG", 2, "Aruban Florin", "ƒ" },
                    { new Guid("f667c2a3-5fac-b765-19c6-c65eb6d1c5a6"), "ARS", 2, "Argentine Peso", "AR$" },
                    { new Guid("fa0c8d5a-d7ad-d6ef-c44c-000085157da7"), "CLP", 0, "Chilean Peso", "CL$" },
                    { new Guid("fb14d36d-e4ae-ce2a-0874-5f9bbaf3da54"), "Artsakh", 2, "Artsakh Dram", "դր." },
                    { new Guid("fca255c7-60b6-4f09-0d71-2c90fcd40753"), "BHD", 3, "Bahraini Dinar", "BD" },
                    { new Guid("fd4cad0d-8381-fc1c-78ca-2aca02283588"), "XOF", 2, "West African CFA Franc BCEAO", "₣" },
                    { new Guid("fdaa9392-8e6e-d492-bb85-e72de96fd369"), "UGX", 2, "Ugandan Shilling", "USh" },
                    { new Guid("ff1bede6-ec71-2ab0-bbf8-7ff7e45ea08d"), "EGP", 2, "Egyptian Pound", "E£" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("02a94805-cd8a-6362-c147-e79e4f88cba9"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("030483f1-a13c-1859-73b9-752835a31c07"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("0a4231a1-7e53-1a6d-2523-079b0e28f991"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("0c2207d4-a840-043c-a181-13629f23a763"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("0d956a48-d79a-dea3-d9f6-fe8a13803a97"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("0dd3fce2-1222-e0e6-a029-704038803f37"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("1289187c-d210-cdae-27ae-a1e09562a989"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("15127fd9-5505-772c-09f4-a998ebe7d84e"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("15656902-67e6-5096-baae-b843d97cafd7"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("19c11074-e05c-e42f-5957-2628e9510004"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("1b522f66-c212-d240-c3c1-95f3df817b0c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("1bd8d6bb-55fc-36c3-03ed-6378bc630669"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("1c7010ea-6905-a818-1dc8-9906b9019c35"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("1d521a8c-1e10-4db2-139d-c9ddfa30002f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("1fdc9b26-aab1-c5dc-b575-a68220158602"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("20758c97-14c5-0a1a-f188-f86e764e90da"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("22d1a99d-f0fd-1d1b-b281-6592e00f28ad"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2339ec2f-a504-3ac2-c138-da22847f9b7c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("23a6f372-126a-5fb7-033d-9a2529a3b875"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2428a728-cc03-1770-c9e1-d5d3f5041bfd"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("264a68ea-3fe2-4a56-fb94-93fad725556e"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("285dfed9-f150-16ed-7451-b193e8bd0e0c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("297a1d27-54c7-bdea-6a11-0781a1adbd2d"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2a050d05-a326-9d10-0fb0-6176ee1db8e8"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2a574ebe-f04e-cd45-c914-49b6c9435a8a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2b0ea592-0b3e-5ba4-28ab-150a385bafcc"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2b5655a0-59db-8bad-a9cc-680367308118"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2d96115b-e8cb-e55d-5770-d22d3e5fb85a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2e05c22f-45aa-9a73-9fd0-854d4ed60178"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("33e99e88-891f-9214-f89b-1e578fa377e0"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("362ac415-3d05-4f89-ef1a-225ce99a3a2b"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("36a1cc65-7ef9-f628-ea8c-af95ba0be3d6"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("38a3c1b4-829b-a079-ee13-5fb1f8368255"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("39bdf548-263b-b98c-f43a-86af1a4d9e8c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("3bad9f41-82f0-1748-27a2-d47adce883a8"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("3be039c5-b2e7-c869-a84f-85437bc8d298"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("3e768d90-f1cf-0469-58ba-5863ae3b894f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("3fb8df59-ac7c-3c4e-8ee9-1700ef2ad90d"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("3fcdf238-6be6-8a7b-64b4-6bc06880d4b7"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("401229af-21e2-0ebb-94c2-f09ee87606cf"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("40554325-f171-792b-a96a-c865112a53e0"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("4143af48-45f7-3f16-945f-a838eeabb062"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("4164005b-94e6-45cb-a1af-078e58a66a87"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("4227f44f-52f9-693e-8b35-154f999f49a2"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("43476567-32cc-eedf-bf2d-2d154db69cd8"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("44c6af00-1d9b-9ff3-464e-a2ca3e56af77"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("457a12d5-3622-804c-5de5-104bb5503310"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("47321ae7-6977-c8ba-d129-a02cd467e3e6"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("48c67697-6737-dacd-e0a3-8b6149c08539"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("497cabbf-8f99-6358-fb8d-10c7f0ed8873"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("4e6b6ab8-67b2-a95a-8b7a-63b568434502"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("4e913f2e-5a32-a01c-cb82-a132af1002d3"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("4fde0da3-c7fc-d1ac-174a-05337056b552"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5010968a-0037-6def-0d6c-1caf8f04ed9f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("508e79f7-53e5-34b2-27e7-df0a7a2652f5"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("50c1f0d5-899f-17ff-8497-1832af4e7670"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("53203a98-f729-bc7e-1712-be17806b8b0a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5409cbec-a9fc-00f2-5aea-084605df5ee9"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5423cf5d-7420-563b-3642-2f69a2f7822c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("559286f0-9158-16e1-1c5a-ef5b2748d7cb"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("55dcd9ca-ba10-12f0-abf9-02dfa6bd3ad0"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("55f9b15f-5eb4-e338-1789-286a1790398d"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5a6da5a4-7482-44d7-b1ab-9678d60901bf"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5b568650-0456-1b07-2d45-d42afcb0d3e9"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5d29220d-29ba-8a8b-4831-a943545b0810"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5e7281f1-c8b3-2546-bc1c-77fa4b39f47c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5ff7ec50-7710-d2e1-50a7-81764b89cbc2"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("60c073b8-2a92-f667-4ac0-9d27d1232f3a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("67614275-c295-93eb-6397-1960a03be6d0"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("678cf412-186c-e9ce-f424-d11554c49415"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("68f951a8-ddb8-06a6-535c-03efee304638"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("6988531f-2c0f-c510-a68a-c0b28696fd8b"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("6a767c32-79c8-096b-f63d-a407c9c8967b"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("6cb14b53-b3e9-e872-099d-b6081da2f962"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("6e156d15-a487-437a-5879-313a5ef39da4"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("6f821189-ba30-9c98-56aa-38112064db7d"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7441bca5-d568-c3c8-7867-2f6bdd2e0c90"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("744e6169-b041-9b1c-a6d4-974080d6d099"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("74b8c512-dd0b-9dc2-a376-7cf7aa684995"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("76e21711-52fc-c8e1-2ab6-7059d9ceca48"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("770c05bb-8592-2f63-0e53-2eab4d629b1c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7b770567-2e71-11e8-e76f-b07162081d63"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7d2c2e91-b5f8-e9d7-63a9-cd82bf0f612f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7e312460-dd5b-62df-aa29-5395cbde54ab"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7eaaeee8-73e1-02b2-12e4-0babe414c5c0"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7f8a7b1a-7e17-4e02-1685-e780c47649c6"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("820e7293-9d3d-f29a-3230-95152cb82906"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("8375f4dc-9f02-d679-4904-cf78daa360cb"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("845d4b1a-32a0-4a8c-33bd-669c608a34c3"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("8522dd3a-4f09-31dc-8690-2810080c1465"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("865e727c-1a56-f1f1-b941-5bf0ea0679c9"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("86a6cb2d-72bf-6816-8c21-aaf78f409d11"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("8f676eb4-47c5-c84e-216c-5e3f4e9d327c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("926eca77-9f15-2b68-db43-52af6058eb92"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("94f81835-424d-2d21-d37d-affe097d216e"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("98884324-53da-bf34-fffc-8ac71ad2bb4e"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("991de080-b526-e74f-2941-0d78954faada"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9954e1d1-d339-c1bd-caa1-0f65876dba6c"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9c6da159-d466-bf88-850d-7fb1e36c4e38"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9cc1be6e-a3f0-09a6-354a-05acde9ca8af"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9cd2c5bf-a278-f366-3479-d3fbad222d43"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9ce1bd44-0ebc-0b83-caf0-54b5413dd39d"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9ec98535-c765-76fb-b3a0-76723dc90c5f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9ecde9a9-ad81-da58-5b9a-608f70e1d7d9"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9f39b2f0-bfd4-d113-d6a8-e7bf52b27483"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a0093fc2-1d1b-f9d2-4308-1b0b6febaf99"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a03a80ff-17c5-da03-a2da-b2119613aa6f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a10a44f7-44ba-740f-555d-4c313c9b7677"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a34a0b1a-bb61-1553-e304-831a320f89b3"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a41afad3-9f5b-6ee5-1fc1-b558d8ed6678"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a47b9428-0b75-c0ac-947b-e464145e08b0"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a5da4d34-06e9-0e91-af8b-8df4656a8551"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a8318d34-a02f-20f4-fc0c-de4a1d0d845d"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a83f0076-dba8-821c-36e0-ce931221b956"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a8afda91-e019-0ea0-fed5-b683ec81b9b2"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("a97206d9-bbf4-6a2b-a4dc-96ed2b419af0"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ac3f818d-37c4-8127-2b29-79fc265e4cad"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ae5c7dce-0da4-e7f9-59a2-c1e0ec747f69"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("af34431f-41e8-f7c3-6efb-f4f5504e9a0a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("affb8a7b-6a90-9670-01db-6e066a527dd1"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("b11bc376-a47a-c585-8620-656a77c13b11"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("b1507d3f-5e68-147b-f5bf-abf8b30c703a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("b356e5fe-69d1-2ebd-a6fb-e8e71f0ade0a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("b439a2fe-d174-b9a0-0401-6873d4f1ee24"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("b9f73528-6807-e1ac-225a-7821f5bcd131"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("bb221ac1-7c55-feae-8a0f-3535dbf6d201"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("bb3eb81a-8de5-8518-632b-175f762eb77a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("bdcf2eae-d495-dd75-f088-76080d57e3d9"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("bf3ae3b9-0846-74c4-1652-596350ea9718"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("c04f60fd-b0da-9def-793c-9598ae881435"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("c0dfd9b6-54fb-7327-21ce-bc0fff55df2f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("c1c5af97-029a-4c01-fde1-c064281437c5"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("c38bddf4-a29d-6b76-7408-d47a540aae25"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("c8e8fa4f-bdc3-24a7-e6cc-853513870137"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("cbb16792-48c6-0e0d-a037-217688b3a655"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ce256ef1-ecc4-b3ca-e643-a66a8eccb1cb"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("cf385935-b7e3-623a-4297-591972d27c01"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("cf6aa1ea-10a1-b24c-23a5-5fb03fdde12f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("cfda8d44-5193-1202-7e2c-6374c945725d"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d0319b6f-b5ec-f704-dcc8-690d7c7840e1"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d0b6ec83-0781-82a9-b9f7-495d3c265446"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d12a4f79-1e8c-bbd9-c158-1fe4589fba1b"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d261eb65-f310-f4ec-45f5-12103e765526"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d3c63cb7-d3c1-f4fb-c49a-ea0b307498dd"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d41f5c78-f550-26b4-27e7-9c1890076425"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d59cc2b9-3cf8-5b53-0bca-f31343315bad"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d6d95096-73d6-1255-28bb-1042f482459f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d8eed51b-a077-453f-eeb9-e0d518e4834a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("df7be16e-7d4a-06a2-068f-e02847a4aed5"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e185868b-8361-d093-0e8a-87328b75ddd6"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e3366b73-b522-3659-97b4-927d6d9132ab"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e504b448-b390-35e4-ec21-9a6f1cec68b4"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e59274d8-5375-83dd-4ebe-968ab2cc8107"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e5bf28d5-c9f0-ba92-ffcc-8a7bef5cdcfb"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e7f7d728-50bb-6ab4-f38d-9d150256df4e"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e87ef008-3803-cfd2-4fd6-5e7bc1909085"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ea876644-b12d-a7ad-5be5-ed053be77f59"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("eab80530-6fb9-df81-142d-787d501d0537"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("eb4e9cc2-372e-d597-e676-21f51f3aecc1"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ed4e06a4-e091-a871-d451-e0d09b480f78"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ede1d560-b630-558d-e6a1-8004b2d17ad2"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ee86f9f3-a4ad-f71a-77ef-5911d96c51ac"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("f0f39460-5873-4369-5cdb-49c60235bffe"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("f293e3e4-f89a-c8aa-d614-354c3d5f3f4b"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("f36e5a06-b4d8-3dcf-1bde-04d9705bebcc"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("f667c2a3-5fac-b765-19c6-c65eb6d1c5a6"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("fa0c8d5a-d7ad-d6ef-c44c-000085157da7"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("fb14d36d-e4ae-ce2a-0874-5f9bbaf3da54"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("fca255c7-60b6-4f09-0d71-2c90fcd40753"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("fd4cad0d-8381-fc1c-78ca-2aca02283588"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("fdaa9392-8e6e-d492-bb85-e72de96fd369"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("ff1bede6-ec71-2ab0-bbf8-7ff7e45ea08d"));
        }
    }
}
