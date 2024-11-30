# Способ создания изображения из кода plantUML
1. Лично я использую extention [PlantUML](https://marketplace.visualstudio.com/items?itemName=jebbs.plantuml), не работает на Linux (к моему большому сожалению)
2. Либо можно воспользоваться сайтом www.plantuml.com

Сайт с доккументацией синтакисиса диаграмм классов по [plantUML](https://plantuml.com/class-diagram).

Сайт с доккументацией синтакисиса диаграмм последовательностей по [plantUML](https://plantuml.com/sequence-diagram).

#  [Техническое задание](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#%D1%81%D1%83%D1%89%D0%BD%D0%BE%D1%81%D1%82%D0%B8-%D0%B1%D0%BE%D0%BB%D0%B5%D0%B5-%D0%BF%D0%BE%D0%B4%D1%80%D0%BE%D0%B1%D0%BD%D0%BE)
# **Сущности - паттерны**
- **MenuManager** - [**Singleton (ОДИНОЧКА)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#singleton-%D0%BE%D0%B4%D0%B8%D0%BD%D0%BE%D1%87%D0%BA%D0%B0)
- **Reservation** - [**Factory method (фабричный метод)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#factory-method-%D1%84%D0%B0%D0%B1%D1%80%D0%B8%D1%87%D0%BD%D1%8B%D0%B9-%D0%BC%D0%B5%D1%82%D0%BE%D0%B4)
- **Order** - [**Observer (наблюдатель)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#observer-%D0%BD%D0%B0%D0%B1%D0%BB%D1%8E%D0%B4%D0%B0%D1%82%D0%B5%D0%BB%D1%8C) для уведомления клиентов о статусе заказа.
- **Dish** - [**Decorator (декоратор)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#decorator-%D0%B4%D0%B5%D0%BA%D0%BE%D1%80%D0%B0%D1%82%D0%BE%D1%80) для кастомизации блюд.
- **Drink** - [**Decorator (декоратор)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#decorator-%D0%B4%D0%B5%D0%BA%D0%BE%D1%80%D0%B0%D1%82%D0%BE%D1%80)
- **Employee** - [**Chain of responsibility** (ЦЕПОЧКА ОБЯЗАННОСТЕЙ)](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#chain-of-responsibility-%D1%86%D0%B5%D0%BF%D0%BE%D1%87%D0%BA%D0%B0-%D0%BE%D0%B1%D1%8F%D0%B7%D0%B0%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B5%D0%B9) для распределения задач между сотрудниками.
- **PaymentSystem** - [**Strategy (Стратегия)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#strategy-%D1%81%D1%82%D1%80%D0%B0%D1%82%D0%B5%D0%B3%D0%B8%D1%8F) для методов оплаты и управления инвентарём.
- **PaymentMethod** - [**Strategy (Стратегия)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#strategy-%D1%81%D1%82%D1%80%D0%B0%D1%82%D0%B5%D0%B3%D0%B8%D1%8F)
- **Inventory** - [**Strategy (Стратегия)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#strategy-%D1%81%D1%82%D1%80%D0%B0%D1%82%D0%B5%D0%B3%D0%B8%D1%8F)
- **Supplier** - [**Strategy (Стратегия)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#strategy-%D1%81%D1%82%D1%80%D0%B0%D1%82%D0%B5%D0%B3%D0%B8%D1%8F)
- **LoyaltyProgram** - [**Composite (Компоновщик)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#composite-%D0%BA%D0%BE%D0%BC%D0%BF%D0%BE%D0%BD%D0%BE%D0%B2%D1%89%D0%B8%D0%BA) для системы лояльности.
- **LoyaltyCard** - [**Composite (Компоновщик)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#composite-%D0%BA%D0%BE%D0%BC%D0%BF%D0%BE%D0%BD%D0%BE%D0%B2%D1%89%D0%B8%D0%BA)
- **Report** - [**Template method (шаблонный метод)**](https://github.com/IKdotShark/ProgTech/wiki/Lab2_new_UML#template-method-%D1%88%D0%B0%D0%B1%D0%BB%D0%BE%D0%BD%D0%BD%D1%8B%D0%B9-%D0%BC%D0%B5%D1%82%D0%BE%D0%B4) для создания отчетов.

# Подробное описание работы компонентов, связей и их реальной реализации
---
#### **1. MenuManager**
**Описание:**  
MenuManager управляет списком доступных блюд и напитков (`MenuItem`). Использует Singleton-паттерн, чтобы обеспечить единственную точку доступа к меню.

**Связи:**
- **`MenuManager` → `MenuItem` (manages):**  
    MenuManager управляет коллекцией объектов типа `MenuItem`. Это позволяет добавлять или удалять позиции из меню.

**Реальный пример:**  
Ресторан имеет централизованную систему для редактирования меню. Менеджер может добавить блюдо "Спагетти Болоньезе" в список доступных. Если блюдо временно отсутствует, его можно удалить.

---

#### **2. MenuItem и MenuItemDecorator**
**Описание:**  
`MenuItem` — базовый класс для блюд и напитков. `MenuItemDecorator` расширяет функциональность, позволяя добавлять кастомизации, такие как соусы или гарниры.

**Связи:**
- **`MenuItemDecorator` → `MenuItem` (extends):**  
    Позволяет модифицировать стоимость блюда, добавляя дополнительные опции.

**Реальный пример:**  
Клиент заказывает стейк и добавляет к нему соус "Беарнез". К финальной стоимости блюда добавляется цена соуса.

---

#### **3. Order**
**Описание:**  
`Order` представляет заказ клиента. Он включает в себя список заказанных позиций (`MenuItem`), информацию о клиенте (`Client`) и сотруднике (`Employee`), который обрабатывает заказ.

**Связи:**
- **`Order` → `MenuItem` (contains):**  
    Заказ содержит одну или несколько позиций меню.
- **`Order` → `Client` (created by):**  
    Заказ создается клиентом.
- **`Order` → `Employee` (handled by):**  
    Заказ обрабатывается официантом или другим сотрудником.

**Реальный пример:**  
Клиент заказывает пасту и лимонад. Официант связывает заказ с клиентом и передает его на кухню. После выполнения заказ отмечается как "готов".

---

#### **4. Client**
**Описание:**  
`Client` представляет посетителя, который может создавать заказы и получать уведомления о статусе заказа.

**Связи:**
- **`Client` → `Order` (places):**  
    Клиент создает заказы, выбирая блюда из меню.

**Реальный пример:**  
Клиент делает заказ через приложение ресторана и получает уведомление: "Ваш заказ готов, можете забрать его у стойки."

---

#### **5. Reservation**
**Описание:**  
`Reservation` представляет бронирование столика, включая время, количество человек и тип (например, стандартное или VIP).

**Связи:**
- **`Reservation` → `Client` (booked by):**  
    Клиент делает бронирование.
- **`Reservation` → `Order` (for):**  
    Резервация может быть связана с заказом, если клиент заранее заказывает блюда.

**Реальный пример:**  
Клиент бронирует столик на 19:00 для четверых и предварительно заказывает вино.

---

#### **6. Employee**
**Описание:**  
`Employee` — общий класс для всех сотрудников, таких как официанты (`Waiter`), повара (`Chef`) и менеджеры (`Manager`).

**Связи:**
- **`Employee` → `Inventory` (checks):**  
    Сотрудники могут проверять запасы ингредиентов.

**Реальный пример:**  
Шеф проверяет, достаточно ли продуктов для приготовления стейка, и при необходимости запрашивает пополнение.

---

#### **7. Inventory и Supplier**

**Описание:**  
`Inventory` управляет запасами, а `Supplier` отвечает за их пополнение.
**Связи:**
- **`Inventory` → `Supplier` (replenished by):**  
    Запасы пополняются поставщиком.
- **`Inventory` → `InventoryStrategy` (uses):**  
    Использует стратегию управления запасами для оптимального пополнения.

**Реальный пример:**  
В конце дня менеджер видит, что мука на исходе, и заказывает пополнение у поставщика.

---

#### **8. Report**
**Описание:**  
`Report` собирает данные о заказах, сотрудниках и платежах за указанный период.

**Связи:**
- **`Report` → `Order` (logs):**  
    В отчете фиксируются выполненные заказы.
- **`Report` → `Employee` (logs staff):**  
    Отчет содержит информацию о сотрудниках, которые обслуживали заказы.
- **`Report` → `PaymentMethod` (logs payment):**  
    Указаны методы оплаты (наличные, карта и т.д.).

**Реальный пример:**  
Менеджер генерирует отчет за неделю, видя, что 70% оплат было через карты, а лучший официант обработал 30 заказов.

---

#### **9. PaymentSystem и PaymentMethod**
**Описание:**  
`PaymentSystem` отвечает за обработку платежей через различные методы (`Cash`, `Card`, `OnlinePayment`).

**Связи:**
- **`PaymentSystem` → `PaymentMethod` (processes):**  
    Платежная система вызывает методы оплаты (`pay`, `refund`).

**Реальный пример:**  
Клиент оплачивает заказ через приложение, используя банковскую карту.

---

#### **10. LoyaltyProgram и LoyaltyCard**
**Описание:**  
Система лояльности позволяет клиентам накапливать баллы (`LoyaltyCard`) и использовать их для оплаты.

**Связи:**
- **`LoyaltyProgram` → `Client` (belongs to):**  
    Программа лояльности связана с клиентом.
- **`LoyaltyProgram` → `LoyaltyCard` (uses):**  
    Карта лояльности используется для накопления и списания баллов.

**Реальный пример:**  
Клиент получает 50 баллов за заказ на 500 рублей и использует их в следующий раз для оплаты десерта.

