﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Impl;
using kseo_nx.Models;

namespace kseo_nx.Helpers
{
    public static class Database
    {
        //Status osoby
        public const string cZabezpieczona = "ZAB";
        public const string cWspolpracownik = "WSP";
        public const string cFigurant = "FIG";
        public const string cBezRoli = "BEZ";

 
        
        static string[] _organizationalUnits =
        {
          "Oddział Kryminalny KGŻW", "MOŻW Warszawa", "OŻW Kraków", "OŻW Elbląg", "OŻW Żagań"
        };

        static string[] _countries =
        {
          "AFGANISTAN",
"ALBANIA",
"ALGIERIA",
"ANDORA",
"ANGOLA",
"ANGUILLA",
"ANTARKTYDA",
"ANTIGUA I BARBUDA",
"ANTYLE HOLENDERSKIE",
"ARABIA SAUDYJSKA",
"ARGENTYNA",
"ARMENIA",
"ARUBA",
"AUSTRALIA",
"AUSTRIA",
"AZERBEJDŻAN",
"BAHAMY",
"BAHRJAN",
"BANGLADESZ",
"BARBADOS",
"BELGIA",
"BELIZE",
"BERMUDY",
"BEZPAŃSTWOWIEC",
"BHUTAN",
"BIAŁORUŚ",
"BIRMA (MYANMAR)",
"BOLIWIA",
"BOŚNIA,HERCEGOWINA",
"BOTSWANA",
"BRAK DANYCH",
"BRAZYLIA",
"BRUNEI",
"BRYTYJSKIE TERYTORIUM OCEANU INDYJSKIEGO",
"BUŁGARIA",
"BURKINA FASO (GÓRNA WOLTA)",
"BURUNDI",
"CHILE",
"CHINY",
"CHORWACJA",
"CYPR",
"CZAD",
"CZECHOSŁOWACJA",
"CZECHY",
"DANIA",
"DEMOKRATYCZNA REPUBLIKA KONGA (ZAIR)",
"DOMINIKA",
"DOMINIKANA",
"DŻIBUTI",
"EGIPT",
"EKWADOR",
"ERYTREA",
"ESTONIA",
"ETIOPIA",
"FALKLANDY/MALWINY",
"FIDŻI",
"FILIPINY",
"FINLANDIA",
"FRANCJA",
"GABON",
"GAMBIA",
"GHANA",
"GIBRALTAR",
"GRECJA",
"GRENADA",
"GRENLANDIA",
"GRUZJA",
"GUAM",
"GUJANA",
"GWADELUPA",
"GWATEMALA",
"GWINEA",
"GWINEA BISSAU",
"GWINEA RÓWNIKOWA",
"HAITI",
"HISZPANIA",
"HOLANDIA",
"HONDURAS",
"HONGKONG",
"INDIE",
"INDONEZJA",
"IRAK",
"IRAN",
"IRLANDIA",
"ISLANDIA",
"IZRAEL",
"JAMAJKA",
"JAPONIA",
"JEMEN",
"JORDANIA",
"JUGOSŁAWIA",
"KAJMANY",
"KAMBODŻA (KAMPUCZA)",
"KAMERUN",
"KANADA",
"KATAR",
"KAZACHSTAN",
"KENIA",
"KIRGISTAN (KIRGIZJA)",
"KIRIBATI",
"KOLUMBIA",
"KOMORY",
"KONGO",
"KOREA POŁUDNIOWA",
"KOREAŃSKA REPUBLIKA LUDOWO-DEMOKRATYCZNA (KOREA PÓŁNOCNA)",
"KOSTARYKA",
"KUBA",
"KUWEJT",
"LAOS",
"LESOTHO",
"LIBAN",
"LIBERIA",
"LIBIA",
"LICHTENSTEIN",
"LITWA",
"LUKSEMBURG",
"ŁOTWA",
"MACEDONIA",
"MADAGASKAR",
"MAKAU",
"MALAWI",
"MALEDIWY",
"MALEZJA",
"MALI",
"MALTA",
"MAROKO",
"MARTYNIKA",
"MAURETANIA",
"MAURITIUS",
"MAYOTTE",
"MEKSYK",
"MIKRONEZJA",
"MOŁDAWIA",
"MONAKO",
"MONGOLIA",
"MONTSERRAT",
"MOZAMBIK",
"NAMIBIA",
"NAURU",
"NEPAL",
"NIEMCY",
"NIGER",
"NIGERIA",
"NIKARAGUA",
"NIUE",
"NORFOLK",
"NORWEGIA",
"NOWA KALEDONIA",
"NOWA ZELANDIA",
"NOWE HEBRYDY",
"OMAN",
"PAKISTAN",
"PALAU",
"PALESTYNA",
"PANAMA",
"PAPUA NOWA GWINEA",
"PARAGWAJ",
"PERU",
"PITCAIRN",
"POLINEZJA",
"POLSKA",
"POLSKIE BEZ NR PESEL",
"PORTORYKO",
"PORTUGALIA",
"REPUBLIKA ŚRODKOWOAFRYKAŃSKA",
"REPUBLIKA ZIELONEGO PRZYLĄDKA",
"REUNION",
"RODEZJA",
"ROSJA",
"RPA (REPUBLIKA POŁUDNIOWEJ AFRYKI)",
"RUANDA",
"RUMUNIA",
"SAHARA ZACHODNIA",
"SALWADOR",
"SAMOA AMERYKAŃSKIE",
"SAMOA ZACHODNIE",
"SAN MARINO",
"SENEGAL",
"SERBIA,CZARNOGÓRA",
"SESZELE",
"SIERRA LEONE",
"SIKKIM",
"SINGAPUR",
"SŁOWACJA",
"SŁOWENIA",
"SOMALIA",
"SRI LANKA (CEJLON)",
"SUAZI",
"SUDAN",
"SURINAM",
"SYRIA",
"SZWAJCARIA",
"SZWECJA",
"TADŻYKISTAN",
"TAJLANDIA (SYJAM)",
"TAJWAN",
"TANZANIA",
"TIMOR",
"TOGO",
"TOKELAU",
"TONGA",
"TRYNIDAD I TOBAGO",
"TUNEZJA",
"TURCJA",
"TURKIESTAN",
"TURKMENISTAN (TURKMENIA)",
"TURKS I CAICOS",
"TUVALU",
"UGANDA",
"UKRAINA",
"URUGWAJ",
"USA (STANY ZJEDNOCZONE AMERYKI)",
"UZBEKISTAN",
"VANUATU",
"WAKE",
"WALLIS I FUTUNA",
"WATYKAN",
"WENEZUELA",
"WĘGRY",
"WIELKA BRYTANIA",
"WIETNAM",
"WŁOCHY",
"WSPÓLNOTA NIEPODLEGŁYCH PAŃSTW",
"WYBRZEŻE KOŚCI SŁONIOWEJ",
"WYSPY BOŻEGO NARODZENIA",
"WYSPY COOKA",
"WYSPY DZIEWICZE (USA)",
"WYSPY DZIEWICZE (WLK. BRYT.)",
"WYSPY KOKOSOWE",
"WYSPY MARSHALLA",
"WYSPY SALOMONA",
"WYSPY ŚWIĘTEGO TOMASZA I KSIĘŻYCA",
"WYSPY ZIELONEGO PRZYLĄDKA",
"ZAMBIA",
"ZIMBABWE (RODEZJA)",
"ZJEDNOCZONE EMIRATY ARABSKIE",
"ZSRR"
        };

        static string[] _sex =
        {
          "KOBIETA","MĘŻCZYZNA"
        };

        static string[] Ranks = 
        {
            //"Proszę wybrać stopień wojskowy...",
            "kpr.","mat","st. kpr.","st. mat",
            "plut.","bsmt","st. bsmt","sierż.","bsm.","st. sierż.","st. bsm.",
            "sierż. szt.","bsm. szt.","st. sierż. szt.","st. bsm. szt.",
            "mł. chor.","mł. chor. mar.","chor.", "chor. mar.","st. chor.","st. chor. mar.",
            "mł. chor. szt.","mł. chor. szt. mar.",
            "chor. szt.","chor. szt. mar.","st. chor. szt.","st. chor. szt. mar.",
            "ppor.", "ppor. mar.","por.","por. mar.","kpt.","kpt. mar.",
            "mjr","kmdr ppor.", "ppłk","kmdr por.","płk","kmdr",
            "gen. bryg.","kadm.","gen. dyw.","wadm.","gen. broni","adm. floty","gen.","adm."
        };



        //Powód zabezpieczenia

        private static DictItem[] _reservationPurposes =
        {
            new DictItem() {Id = 1, Name = "A", Description = "ROZPRACOWANIE"},
            new DictItem() {Id = 2, Name = "AA", Description = "PRZED ZAINTERESOWANIEM OPERACYJNYM"},
            new DictItem() {Id = 3, Name = "QA", Description = "POSTĘPOWANIE SPRAWDZAJĄCE"},
            new DictItem() {Id = 4, Name = "QK", Description = "KONCESJA"},
            new DictItem() {Id = 5, Name = "J", Description = "DOPUSZCZENIE DO INFORMACJI NIEJAWNYCH"},
            new DictItem() {Id = 6, Name = "QC", Description = "RODZINA (KONKUBENT) OPINIOWANEGO W POST. SPRAW."},
            new DictItem() {Id = 7, Name = "Q", Description = "OPINIOWANIE"},
            new DictItem() {Id = 8, Name = "U", Description = "SPRAWDZENIE KANDYDATA DO ŻW"},
            new DictItem() {Id = 9, Name = "AB", Description = "PRZED REJESTRACJĄ"},
            new DictItem() {Id = 10, Name = "AC", Description = "PRZED ROZMOWĄ"},
            new DictItem() {Id = 11, Name = "AD", Description = "PRZED ZASADZKĄ"},
            new DictItem() {Id = 12, Name = "KU", Description = "KANDYDAT DO SŁUŻBY (PRACY)"},
            new DictItem() {Id = 13, Name = "KW", Description = "RODZINA KANDYDATA DO SŁUŻBY (PRACY)"},
            new DictItem() {Id = 14, Name = "KZ", Description = "RODZINA FUNKCJONARIUSZA (PRACOWNIKA)"},
            new DictItem() {Id = 15, Name = "PA", Description = "PRZED (PO) ZATRZYMANIEM (-IU)"},
            new DictItem() {Id = 16, Name = "PB", Description = "PRZED PRZESZUKANIEM"},
            new DictItem() {Id = 17, Name = "PC", Description = "PRZED PRZESŁUCHANIEM"},
            new DictItem() {Id = 18, Name = "PD", Description = "PRZED PRZEDSTAWIENIEM ZARZUTU"},
            new DictItem() {Id = 19, Name = "PE", Description = "PRZED (PO) ZASTOSOWANIEM (IU) ŚRODKA ZAPOBIEGAWCZEGO"},
            new DictItem() {Id = 20, Name = "PF", Description = "PRZED POSZUKIWANIEM"},
            new DictItem() {Id = 21, Name = "QD", Description = "KONTAKT OPINIOWANEGO W POST. SPRAW."}
        }; 


        //Przyczyna zakończenia zabezpieczenia

        private static DictItem[] _reservationEndReasons =
        {
            new DictItem() {Id = 1, Name = "A", Description = "UPŁYNIĘCIE TERMINU"},
            new DictItem() {Id = 2, Name = "AA", Description = "NAWIĄZANIE WSPÓŁPRACY"},
            new DictItem() {Id = 3, Name = "QA", Description = "INNE"},
            new DictItem() {Id = 4, Name = "QK", Description = "KONCESJA"},
            new DictItem() {Id = 5, Name = "J", Description = "DOPUSZCZENIE DO INFORMACJI NIEJAWNYCH"},
            new DictItem() {Id = 6, Name = "QC", Description = "RODZINA (KONKUBENT) OPINIOWANEGO W POST. SPRAW."},
            new DictItem() {Id = 7, Name = "Q", Description = "OPINIOWANIE"},
            new DictItem() {Id = 8, Name = "U", Description = "SPRAWDZENIE KANDYDATA DO ŻW"}
        };


        public static string[] OrganizationalUnits {get { return _organizationalUnits; }}
        public static string[] Countries { get { return _countries; } }
        public static string[] Sex { get { return _sex; } }
        public static DictItem[] ReservationPurposes { get { return _reservationPurposes; } }
        public static DictItem[] ReservationEndReasons { get { return _reservationEndReasons; } }
    }
    
}
