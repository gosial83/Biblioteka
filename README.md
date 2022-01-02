
# Zad 3. OOP C#

Uwaga: Tak jak poprzednio macie już utworzony projekt, więc proszę abyście go użyli i nie tworzyli nowych plików konfiguracyjnych. Przypominam również, że tym razem oceniane będzie nie tylko sama poprawność rozwiązania, ale zarówno zgodność z konwencją (nazewnictwo, mała/wielka litera itd.) jak i poprawność samego oddania zadania (git).

Tym razem waszym zadaniem jest utworzenie systemu bibliotecznego.

Zadania:

1. Utwórz klasę reprezentującą użytkownika `User`, zawierającego takie właściwości jak: Imie, nazwisko, wiek, email, hasło, flagę isActive i kolekcję wypożyczonych książek. Uwaga: email na zewnątrz klasy powinien być tylko do odczytu, a tworzony zawsze na bazie pierwszych dwóch liter imienia i ostatnich dwóch liter nazwiska. Np. Adam Nowak - adak@example.com. Podpowiedź: Możesz użyć publicznej, bezparametrowej metody `GenerateEmail()` która używa wcześniej ustawionych imienia i nazwiska. Podpowiedź 2: Można również użyć konstruktora ;) .
2. Tworzenie użytkownika - dodaj możliwość tworzenia nowego użytkownika. Użytkownicy mogą być trzymani w pamięci w "udawanej" bazie danych w postaci statycznej kolekcji. (Zastanów się jak i gdzie taka kolekcja powinna być zadeklarowana, żeby było najczytelniej/najczyściej). Tworzenie musi mieć odpowiednią walidację - imie i nazwisko nie krótsze niż 2 litery, wiek między 18 a 99 lat.
3. Wyświetlanie użytkowników - powinna być możliwość wyświetlenia listy użytkowników, np. w takiej formie:

# Name | Last Name | Email | Age | IsActive | Books 
===============================================================================

John | Smith | josm@example.com | 43 | true | 2

Jane | Doe | jado@example.com | 21 | false | 4

(trochę mi się rozjechało w markup'ie, ale wiecie o co chodzi :D)

4. Usuwanie użytkowników - wymaga wpisania emaila użytkownika i wyświetla odpowiedni komunikat w przypadku nie znalezienia.
5. Książki - utwórz klasę `Book` i interfejs `IBorrowable` który klasa `Book` implementuje. `IBorrowable` powinien mieć metodę `Borrow` która umożliwa wypożyczenie danej ksiązki danemu użytkownikowi (Jak? Jaką strukturę powinna mieć klasa book? Sam wymyśl!).
6. Dodawanie nowych książek - możliwość utworzenia nowej ksiązki z poziomu konsoli.
7. Wypożyczanie książki - Możliwość odznaczenia, że dany użytkownik A wypożycza właśnie książkę B. Pamiętajcie, że musicie sprawdzać, czy dana książka nie jest obecnie wypożyczona przez innego użytkownika. (zakładamy, że na stanie jest tylko 1 sztuka każdej ksiązki).


Przy wykonywaniu pracy domowej zwróćcie uwagę na odpowiednią strukturę projektu, np. klasy reprezentujące modele w oddzielnym folderze itd.

Powodzenia :)

# Dla przypomnienia forma oddania zadania
Zadanie powinno być oddane w formie commitów na oddzielnym branchu o nazwie w konwecji `nrzadania_ImięNazwisko` (np: `3_PatrykSzwermer`)

Jako że to początek przygody z GIT'em przejdźmy razem przez wszystkie kroki które musisz wykonać.

## :construction_worker: 
1. Przejdź w konsoli do miejsca gdzie chcesz mieć repozytorium.
2. Przejdź na branch master `git checkout master` i zpulluj jego obecny stan. `git pull`
3. Stwóż brancha o dobrej nazwie na podstawie mastera, np: `2_PatrykSzwermer` poprzez 
```
git checkout -b 3_PatrykSzwermer
```
lub z wykorzystaniem ulubionego GIT GUI.

4. Upewnij się że poprawnie zalożyleś/aś brancha. 
```
git status
```

Tekst w konsoli powinien głosić `On branch 3_PatrykSzwermer` (w moim przypadku)

5. Wykonaj zadanie i commituj wyniki. Aby wykonać commit, najprościej:
```
git add -A
git commit -m "this is my commit message"
```
5. Wyślij zmiany na github'a poprzez push 
```
git push
```
6. Twoje zmiany oraz branch powinny znajdować się na github'ie, upewnij się tutaj: https://github.com/infoshareacademy/jcszr4-homeworks/branches
7. Chcesz dodać kolejne zmiany? commit i push ... i tak aż do zakończenia :smiley_cat:
8. Tworzymy PR bazując na naszym branchu.

---

# :clock3: Termin
## 22.10.2021, 23:59 
