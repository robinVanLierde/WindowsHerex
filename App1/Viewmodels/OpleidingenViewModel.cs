using App1.Views;
using ProjectWindows.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.Viewmodels
{
    class OpleidingenViewModel : INotifyPropertyChanged
    {
        public ICommand navHome { get; set; }
        MainViewModel mvm;
        private string _selectedOpleiding;   
        public string SelectedOpleiding
        {
            get { return _selectedOpleiding; }
            set
            {
                if (value == _selectedOpleiding)                
                    return;                                 
                _selectedOpleiding = value;
                OnPropertyChanged("SelectedOpleiding");
                ChangeOpleiding();

            }
        }
        private string _titel;
        public string Titel
        {
            get { return _titel; }
            set
            {
                if (value == _titel)
                    return;
                _titel = value;
                OnPropertyChanged("Titel");

            }
        }
        private string _mainTekst;
        public string MainTekst
        {
            get { return _mainTekst; }
            set
            {
                if (value == _mainTekst)
                    return;
                _mainTekst = value;
                OnPropertyChanged("MainTekst");

            }
        }

        public List<String> Opleidingen { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public OpleidingenViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
            Opleidingen = new List<string>();
            Opleidingen.Add("Toegepaste Informatica");
            Opleidingen.Add("Bedrijfsmanagement");
            Opleidingen.Add("Office management");
            Opleidingen.Add("Retail management");
        }

        public bool CanExecuteMethod(object obj)
        {
            return true;
        }

        public void navHomepage(object obj)
        {

            mvm.SelectedViewModel = new MainView(mvm);

        }

        public void ChangeOpleiding()
        {
            switch (SelectedOpleiding)
            {
                case "Bedrijfsmanagement":
                    Titel = "Talentmanagement: je talent optimaal benutten";
                    MainTekst = "De opleiding bachelor in het bedrijfsmanagement duurt drie jaar. Je kiest vanaf het eerste jaar je afstudeerrichting. Vanaf de eerste les kan je gaan voor wat je echt boeit en zie je al onmiddellijk de link met het beroepsleven.\n\n De opleiding bedrijfsmanagement wil je actief begeleiden in je persoonlijke ontwikkeling en in de ontwikkeling van je competenties en talenten.Je krijgt een coach die met jou 1 - to - 1 je volledige studietraject begeleidt en je met raad en daad bijstaat.In het eerste jaar ligt de focus vooral op jezelf leren kennen als student en op je studieproces.\n\nIn het tweede en het derde jaar ligt de focus op je persoonlijke ontwikkeling en op je beroepskeuze. Je coach bespreekt ook samen met jou de ideale stageplaats als voorbereiding op de job die je graag wil. Je leert ook meteen om een goed CV op te stellen dat vertrekt van je eigen sterktes. Heel belangrijk is dat jij altijd de centrale figuur bent in de coachingsessies. Jij bent altijd diegene die voor jezelf onderzoekt wat je kan en wat je wil. En je onderneemt ook eigen acties om jezelf bij te sturen naar een optimale slaagkans.";
                    break;
                case "Office management":
                    Titel = "Office management";
                    MainTekst = "Je bent een doener en je houdt van uitdagingen. In een team ben jij diegene die organiseert en coördineert. Je weet van aanpakken en bent een punctuele multitasker. Voor jou moeten de zaken vooruitgaan, goed getimed en gepland. Talen zijn volledig je ding en je communiceert graag. Je blik is internationaal, je aanpak no-nonsense.\n\n De opleiding office management bereidt je perfect voor op een boeiende job. Dit gebeurt op een veelzijdige manier om tegemoet te komen aan het diverse pakket van taken maar met een gerichte focus op drie pijlers:\n\nTalenkennis: \n Nederlands, Frans, Engels en mogelijk een vierde taal Spaans of Duits.Je wordt de meertalige medewerker die in elk bedrijf en elke organisatie onmisbaar is.\n\nCommunicatievaardigheden & organisational skills: \n efficiënt researchen, prioriteiten detecteren, oplossingsgericht handelen, correct communiceren, overtuigen en onderhandelen, professioneel rapporteren en impactvol presenteren. Je wordt de multifunctionele duizendpoot die de waaier aan taken perfect onder controle heeft. \n\n ICT: \n je wordt professionele expert in de meest gangbare softwarepakketten. ";
                    break;
                case "Toegepaste Informatica":
                    Titel = "Toegepaste informatica: een boeiende uitdaging";
                    MainTekst = "Heb je interesse om een spamfilter, webbrowser of webapplicatie te programmeren?\n\n Zin om een pc samen te stellen, een firewall of netwerk op te zetten?\n\n Gebeten om een oplossing te vinden voor elk IT-probleem?\n\n Zin om mee te werken aan de ontwikkeling van een applicatie van start tot finish?\n\n Dan is de bachelor in de toegepaste informatica iets voor jou!\n\n De IT’er van vandaag is veel meer dan alleen maar een technische expert. Hij of zij moet tegelijkertijd een ondernemende, communicatieve en klantgerichte teamspeler zijn. IT is namelijk geëvolueerd van een zuiver technisch verhaal naar ’IT as a service and support tool’. \n\n De moderne IT’er is dan ook vooral een ITmanager: iemand die in staat is de strategie van een bedrijf te vertalen naar ICT-oplossingen. De bacheloropleiding toegepaste informatica speelt met haar programma dan ook perfect in op wat de markt en het bedrijfsleven van vandaag exact verlangen van een IT’er. Om performant te kunnen functioneren in een all-round managementfunctie zal je dus tijdens je opleiding niet alleen vlot de nodige IT-skills leren beheersen. Ook business en ondernemerschap maken een belangrijk onderdeel uit van de training. \n\n Binnen de opleiding is er ruime aandacht voor wat wij noemen ‘een authentieke leeromgeving’. Je zal vanaf het eerste jaar in verschillende vakken en projecten boeiende opdrachten mogen uitwerken die rechtstreeks verband houden met de beroepspraktijk en het werkveld. En natuurlijk kan je daarbij rekenen op professionele support door onze docenten die altijd vakspecialisten zijn. Zo leer je niet alleen de concrete dagelijkse beroepspraktijk beter kennen, je scherpt ook je communicatieve en sociale vaardigheden aan. Goed kunnen spreken en presenteren, je standpunt duidelijk maken in je team en in het bedrijfsleven, kunnen onderhandelen en overtuigen, … het zijn cruciale skills die je voorbereiden op de beste jobs en je een voorsprong geven op de arbeidsmarkt. \n\n De internationale dimensie is sterk aanwezig in de opleiding. Onze studenten moeten wereldburgers worden en dit kan alleen door ook in je opleiding de kans te krijgen om internationale en interculturele competenties te verwerven. Buitenlandse gastsprekers, de ‘Internationale week’, eventueel studeren of stage lopen in het buitenland en uitwisselingen met anderstalige studenten zullen je kijk op de wereld verruimen.";
                    break;
                case "Retail management":
                    Titel = "Retail management";
                    MainTekst = "De opleiding tot bachelor in het retailmanagement bereidt jou voor op de job van strategisch manager in de detailhandel. Het is een veelzijdige opleiding waarin je kennismaakt met alle aspecten van het leiden van een winkel: zowel de strategie, het commerciële, het financiële, het personeelsaspect, de communicatie en het juridische. Maar het is vooral ook een opleiding waarbij je al doende leert. Want de opleiding wordt enkel aangeboden in de vorm van duaal leren.\n\n Duaal leren betekent dat je om beurten drie weken aan de hogeschool studeert en daarna drie weken op de werkvloer gaat leren - onder begeleiding van een docent-begeleider en van een bedrijfscoach. Er is een hechte samenwerking tussen de coach in het winkelbedrijf en de lesgevers van de HoGent. \n\n Het volledige programma is uitgewerkt in een samenwerking tussen de HoGent en de retailsector. De opleiding wordt gesteund door Comeos, de organisatie van de Belgische handel en diensten. We werken samen met een vijftigtal bedrijven uit de meest diverse sectoren, gespreid over het hele Vlaamse land.\n\n De opleiding werd na een grondig onderzoek in opdracht van de Vlaamse overheid erkend door de minister van Onderwijs, en leidt tot het diploma van (professionele) bachelor. \n\n We richten ons speciaal naar enthousiaste en ondernemende studenten met een hart voor het winkelbedrijf.";
                    break;
            }
        }

        private void OnPropertyChanged(string propName)

        {

            if (PropertyChanged != null)

            {

                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }

        }
    }
}
