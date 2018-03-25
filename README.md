# Cinema-ASP.NET-MVC
Cinema website application in asp.net MVC

---
Poniżej postaram się przedstawić projekt w prostej postaci, jednak cały kod jest dostępny w repozytorium.
Projekt miał na celu poszerzenie mojej wiedzy w technologiach:
- HTML5
- CSS
- Bootstrap
- JavaScript z JQuery
- C#
- ASP.NET MVC
- Entity Framework
- SQL

---

### Aplikacja jest responsywna co znaczy, że dostosowuje się do przeglądarki desktopowej oraz mobilnej ###

### Desktop: ###

![DesktopView](http://i64.tinypic.com/50k49c.jpg)

### Mobile: ###

![MobileView](http://i63.tinypic.com/2i0599y.jpg)

---

### Wybór kina: ###

Użytkownik ma możliwość zmiany kina w pasku nawigacyjnym poprzez:
- wpisanie ręczne nazwy kina (dzięki JQuery Autocomplete wyświetlą się kina które zawierają wpisane znaki)
- zaznaczenie geolokalizacji (Google Maps API - Geolokalizacja wybierze kino najbliższe użytkownikowi)
- wybór z listy

![ChooseCinemaNavigationBar](http://i67.tinypic.com/30seskh.jpg)

---

### Rezerwacja: ###

Sekcja rezerwacji pozwala zmienić kino, DropDownList korzysta ze zmiennych sesji dzieki czemu osoba korzystająca z aplikacji nie jest zmuszona za każdym razem odświeżania strony dbać o to aby kino zostało wybrane. Użytkownik również może sprecyzować jaki film dokładnie go interesuje, typ oraz datę.
Dane są pobierane  oraz filtrowane za każdą interakcją osoby korzystającej z aplikacji.

![Reservation](http://i63.tinypic.com/34yoc3n.jpg)

---

### Produkcje: ###

Aktualne produkcje, które widnieją na ekranie kin bądź będą dopiero dostępne wkrótce.
Użytkownik może wybrać kategorię filmów jaka mu odpowiada.
Po najechaniu myszką na jedną z opcji za pośrednictwem animacji JavaScript pojawi się znaczek "Play". 

![AvailableAndSoon](http://i66.tinypic.com/jr9zqp.jpg)

Po naciśnieciu wyświetli okno modalne ze zwiastunem filmu (Youtube iFrame)

![ModalWindow](http://i65.tinypic.com/qs1o4g.jpg)

oraz przycisk ze szczegółami filmu przekierowujący na stronę z dokładniejszym opisem filmu.

![MovieDetails](http://i64.tinypic.com/2q3dlib.jpg)

---

### Nowości i wydarzenia: ###

![EventsAndNews](http://i66.tinypic.com/mkkbpg.jpg)

---

### Panel Administracyjny: ###

Administrator logujący się do panelu
Ścieżka /Panel/Index
Login: admin@gmail.com
Hasło: ADmin9
Jest w stanie zarządzać (dodawać, usuwać, edytować) wszystkim co pojawi się na stronie:
- Filmami
- Kinami (z podglądem na Mapę Google)
- Kategoriami filmów
- Repertuarem
- Banerami (slider na głownej stronie)
- Wydarzeniami
- Nowościami

![AdminPanel](http://i63.tinypic.com/v5bm9s.jpg)
