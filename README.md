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

![DesktopView](http://url/to/img.png)

### Mobile: ###

![MobileView](http://url/to/img.png)

---

### Wybór kina: ###

Użytkownik ma możliwość zmiany kina w pasku nawigacyjnym poprzez:
- wpisanie ręczne nazwy kina (dzięki JQuery Autocomplete wyświetlą się kina które zawierają wpisane znaki)
- zaznaczenie geolokalizacji (Google Maps API - Geolokalizacja wybierze kino najbliższe użytkownikowi)
- wybór z listy

![ChooseCinemaNavigationBar](http://url/to/img.png)

---

### Rezerwacja: ###

Sekcja rezerwacji pozwala zmienić kino, DropDownList korzysta ze zmiennych sesji dzieki czemu osoba korzystająca z aplikacji nie jest zmuszona za każdym razem odświeżania strony dbać o to aby kino zostało wybrane. Użytkownik również może sprecyzować jaki film dokładnie go interesuje, typ oraz datę.
Dane są pobierane za każdą interakcją oraz filtrowane.

![Reservation](http://url/to/img.png)

