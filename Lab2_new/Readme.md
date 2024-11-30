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

