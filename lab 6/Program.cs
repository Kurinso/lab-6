using System;
using System.Collections.Generic;



/// <summary>
/// Интерфейс для объектов, способных мяукать
/// </summary>
public interface IMeowable
{
    /// <summary>
    /// Издает звук мяуканья
    /// </summary>
    void Meow();
}

/// <summary>
/// Интерфейс для выполнения операций с дробями
/// </summary>
public interface IFractionOperations
{
    /// <summary>
    /// Получает вещественное значение дроби
    /// </summary>
    /// <returns>Вещественное число, представляющее значение дроби</returns>
    double GetRealValue();

    /// <summary>
    /// Устанавливает новое значение числителя
    /// </summary>
    /// <param name="numerator">Новое значение числителя</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если после установки получается некорректная дробь
    /// </exception>
    void SetNumerator(int numerator);

    /// <summary>
    /// Устанавливает новое значение знаменателя
    /// </summary>
    /// <param name="denominator">Новое значение знаменателя</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если знаменатель равен нулю
    /// </exception>
    void SetDenominator(int denominator);
}

//КЛАССЫ ДЛЯ КОТОВ 

/// <summary>
/// Представляет кота с возможностью мяукать
/// </summary>
public class Cat : IMeowable
{
    private string _name;
    private int _meowCount = 0;

    /// <summary>
    /// Получает имя кота
    /// </summary>
    /// <value>Имя кота</value>
    public string Name
    {
        get => _name;
        private set
        {
            ValidateName(value);
            _name = value;
        }
    }

    /// <summary>
    /// Получает количество совершенных мяуканий
    /// </summary>
    /// <value>Количество раз, когда кот мяукал</value>
    public int MeowCount => _meowCount;

    /// <summary>
    /// Проверяет корректность имени кота
    /// </summary>
    /// <param name="name">Проверяемое имя</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если имя некорректно
    /// </exception>
    private void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя кота не может быть пустым или содержать только пробелы", nameof(name));
        }

        if (name.Length > 50)
        {
            throw new ArgumentException("Имя кота не может быть длиннее 50 символов", nameof(name));
        }
    }

    /// <summary>
    /// Проверяет корректность количества мяуканий
    /// </summary>
    /// <param name="count">Проверяемое количество</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Выбрасывается, если количество некорректно
    /// </exception>
    private void ValidateMeowCount(int count)
    {
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Количество мяуканий должно быть положительным числом");
        }

        if (count > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Кот не может мяукать больше 100 раз подряд");
        }
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Cat"/>
    /// </summary>
    /// <param name="name">Имя кота</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если имя некорректно
    /// </exception>
    public Cat(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Заставляет кота мяукнуть один раз
    /// </summary>
    /// <remarks>
    /// Выводит на консоль сообщение в формате "Имя: мяу!"
    /// </remarks>
    public void Meow()
    {
        Meow(1);
    }

    /// <summary>
    /// Заставляет кота мяукнуть заданное количество раз
    /// </summary>
    /// <param name="count">Количество мяуканий</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Выбрасывается, если количество некорректно
    /// </exception>
    /// <remarks>
    /// Выводит на консоль сообщение в формате "Имя: мяу-мяу-...-мяу!"
    /// </remarks>
    public void Meow(int count)
    {
        ValidateMeowCount(count);

        _meowCount += count;

        if (count == 1)
        {
            Console.WriteLine($"{Name}: мяу!");
        }
        else
        {
            string meows = string.Join("-", System.Linq.Enumerable.Repeat("мяу", count));
            Console.WriteLine($"{Name}: {meows}!");
        }
    }

    /// <summary>
    /// Возвращает строковое представление кота
    /// </summary>
    /// <returns>Строка в формате "кот: Имя"</returns>
    public override string ToString()
    {
        return $"кот: {Name}";
    }
}

/// <summary>
/// Представляет робота-кота, способного мяукать
/// </summary>
public class RobotCat : IMeowable
{
    private string _model;

    /// <summary>
    /// Получает модель робота-кота
    /// </summary>
    /// <value>Модель робота</value>
    public string Model
    {
        get => _model;
        private set
        {
            ValidateModel(value);
            _model = value;
        }
    }

    /// <summary>
    /// Проверяет корректность модели робота-кота
    /// </summary>
    /// <param name="model">Проверяемая модель</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если модель некорректна
    /// </exception>
    private void ValidateModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Модель робота-кота не может быть пустой", nameof(model));
        }
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RobotCat"/>
    /// </summary>
    /// <param name="model">Модель робота-кота</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если модель некорректна
    /// </exception>
    public RobotCat(string model)
    {
        Model = model;
    }

    /// <summary>
    /// Заставляет робота-кота мяукнуть
    /// </summary>
    /// <remarks>
    /// Выводит на консоль сообщение в формате "Модель: БИП-МЯУ!"
    /// </remarks>
    public void Meow()
    {
        Console.WriteLine($"{Model}: БИП-МЯУ!");
    }

    /// <summary>
    /// Возвращает строковое представление робота-кота
    /// </summary>
    /// <returns>Строка в формате "робот-кот: Модель"</returns>
    public override string ToString()
    {
        return $"робот-кот: {Model}";
    }
}

/// <summary>
/// Декоратор для подсчета количества мяуканий объекта
/// </summary>
/// <remarks>
/// Реализует паттерн Декоратор для добавления функциональности подсчета
/// без изменения исходного класса
/// </remarks>
public class MeowCounter : IMeowable
{
    private readonly IMeowable _meowable;
    private int _meowCount = 0;

    /// <summary>
    /// Получает базовый объект, способный мяукать
    /// </summary>
    /// <value>Декорируемый объект</value>
    public IMeowable Meowable => _meowable;

    /// <summary>
    /// Получает количество совершенных мяуканий
    /// </summary>
    /// <value>Количество мяуканий</value>
    public int MeowCount => _meowCount;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="MeowCounter"/>
    /// </summary>
    /// <param name="meowable">Объект для декорирования</param>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="meowable"/> равен null
    /// </exception>
    public MeowCounter(IMeowable meowable)
    {
        _meowable = meowable ?? throw new ArgumentNullException(nameof(meowable), "Объект для декорирования не может быть null");
    }

    /// <summary>
    /// Вызывает мяуканье и увеличивает счетчик
    /// </summary>
    public void Meow()
    {
        _meowable.Meow();
        _meowCount++;
    }

    /// <summary>
    /// Возвращает строковое представление декоратора
    /// </summary>
    /// <returns>Строковое представление</returns>
    public override string ToString()
    {
        return $"Счетчик мяуканий для {_meowable}";
    }
}

/// <summary>
/// Предоставляет методы для работы с коллекциями мяукающих объектов
/// </summary>
public static class MeowService
{
    /// <summary>
    /// Вызывает мяуканье у всех объектов в коллекции
    /// </summary>
    /// <typeparam name="T">Тип объекта, реализующего IMeowable</typeparam>
    /// <param name="meowables">Коллекция мяукающих объектов</param>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если коллекция равна null
    /// </exception>
    public static void MakeAllMeow<T>(IEnumerable<T> meowables) where T : IMeowable
    {
        if (meowables == null)
        {
            throw new ArgumentNullException(nameof(meowables), "Коллекция не может быть null");
        }

        foreach (var meowable in meowables)
        {
            meowable.Meow();
        }
    }
}

// ================================ КЛАССЫ ДЛЯ ДРОБЕЙ ================================

/// <summary>
/// Представляет математическую дробь с целыми числителем и знаменателем
/// </summary>
/// <remarks>
/// <para>Класс поддерживает основные арифметические операции, сравнение и клонирование.</para>
/// <para>Дроби автоматически сокращаются при создании и изменении.</para>
/// </remarks>
public class Fraction : ICloneable, IFractionOperations, IEquatable<Fraction>, IComparable<Fraction>
{
    private int _numerator;
    private int _denominator;
    private double? _cachedRealValue = null;

    /// <summary>
    /// Получает числитель дроби
    /// </summary>
    /// <value>Целое число - числитель дроби</value>
    public int Numerator
    {
        get => _numerator;
        private set
        {
            if (_numerator != value)
            {
                _numerator = value;
                _cachedRealValue = null;
            }
        }
    }

    /// <summary>
    /// Получает знаменатель дроби
    /// </summary>
    /// <value>Целое положительное число - знаменатель дроби</value>
    /// <remarks>Знаменатель всегда положительный, знак хранится в числителе</remarks>
    public int Denominator
    {
        get => _denominator;
        private set
        {
            ValidateDenominator(value);
            if (_denominator != value)
            {
                _denominator = value;
                _cachedRealValue = null;
            }
        }
    }

    /// <summary>
    /// Проверяет корректность значения знаменателя
    /// </summary>
    /// <param name="denominator">Проверяемое значение знаменателя</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если знаменатель равен нулю
    /// </exception>
    private void ValidateDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен нулю", nameof(denominator));
        }
    }

    /// <summary>
    /// Сокращает дробь до несократимого вида
    /// </summary>
    /// <param name="numerator">Ссылка на числитель для сокращения</param>
    /// <param name="denominator">Ссылка на знаменатель для сокращения</param>
    /// <remarks>
    /// Метод гарантирует, что знаменатель будет положительным,
    /// а дробь - несократимой
    /// </remarks>
    private static void ReduceFraction(ref int numerator, ref int denominator)
    {
        if (numerator == 0)
        {
            denominator = 1;
            return;
        }

        int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
        numerator /= gcd;
        denominator /= gcd;

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
    }

    /// <summary>
    /// Вычисляет наибольший общий делитель двух чисел
    /// </summary>
    /// <param name="a">Первое число</param>
    /// <param name="b">Второе число</param>
    /// <returns>Наибольший общий делитель</returns>
    /// <remarks>Используется алгоритм Евклида</remarks>
    private static int GreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Fraction"/>
    /// </summary>
    /// <param name="numerator">Числитель дроби</param>
    /// <param name="denominator">Знаменатель дроби</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если знаменатель равен нулю
    /// </exception>
    public Fraction(int numerator, int denominator)
    {
        ValidateDenominator(denominator);

        int num = numerator;
        int den = denominator;
        ReduceFraction(ref num, ref den);

        _numerator = num;
        _denominator = den;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Fraction"/> из целого числа
    /// </summary>
    /// <param name="wholeNumber">Целое число</param>
    /// <remarks>
    /// Создает дробь со знаменателем 1
    /// </remarks>
    public Fraction(int wholeNumber) : this(wholeNumber, 1) { }

    #region Реализация IFractionOperations

    /// <summary>
    /// Получает вещественное значение дроби
    /// </summary>
    /// <returns>Вещественное число, равное дроби</returns>
    /// <remarks>
    /// Использует кэширование для оптимизации повторных вычислений
    /// </remarks>
    public double GetRealValue()
    {
        if (_cachedRealValue.HasValue)
        {
            return _cachedRealValue.Value;
        }

        _cachedRealValue = (double)Numerator / Denominator;
        return _cachedRealValue.Value;
    }

    /// <summary>
    /// Устанавливает новое значение числителя
    /// </summary>
    /// <param name="numerator">Новое значение числителя</param>
    /// <remarks>
    /// Дробь автоматически сокращается после изменения
    /// </remarks>
    public void SetNumerator(int numerator)
    {
        int num = numerator;
        int den = Denominator;
        ReduceFraction(ref num, ref den);

        Numerator = num;
        Denominator = den;
    }

    /// <summary>
    /// Устанавливает новое значение знаменателя
    /// </summary>
    /// <param name="denominator">Новое значение знаменателя</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если знаменатель равен нулю
    /// </exception>
    /// <remarks>
    /// Дробь автоматически сокращается после изменения
    /// </remarks>
    public void SetDenominator(int denominator)
    {
        ValidateDenominator(denominator);

        int num = Numerator;
        int den = denominator;
        ReduceFraction(ref num, ref den);

        Numerator = num;
        Denominator = den;
    }

    #endregion

    #region Арифметические операции

    /// <summary>
    /// Складывает текущую дробь с другой дробью
    /// </summary>
    /// <param name="other">Дробь для сложения</param>
    /// <returns>Новая дробь - результат сложения</returns>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="other"/> равен null
    /// </exception>
    public Fraction Add(Fraction other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other), "Дробь не может быть null");

        int newNumerator = Numerator * other.Denominator + other.Numerator * Denominator;
        int newDenominator = Denominator * other.Denominator;

        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Складывает текущую дробь с целым числом
    /// </summary>
    /// <param name="number">Целое число для сложения</param>
    /// <returns>Новая дробь - результат сложения</returns>
    public Fraction Add(int number) => Add(new Fraction(number));

    /// <summary>
    /// Вычитает другую дробь из текущей дроби
    /// </summary>
    /// <param name="other">Дробь для вычитания</param>
    /// <returns>Новая дробь - результат вычитания</returns>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="other"/> равен null
    /// </exception>
    public Fraction Subtract(Fraction other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other), "Дробь не может быть null");

        int newNumerator = Numerator * other.Denominator - other.Numerator * Denominator;
        int newDenominator = Denominator * other.Denominator;

        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Вычитает целое число из текущей дроби
    /// </summary>
    /// <param name="number">Целое число для вычитания</param>
    /// <returns>Новая дробь - результат вычитания</returns>
    public Fraction Subtract(int number) => Subtract(new Fraction(number));

    /// <summary>
    /// Умножает текущую дробь на другую дробь
    /// </summary>
    /// <param name="other">Дробь для умножения</param>
    /// <returns>Новая дробь - результат умножения</returns>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="other"/> равен null
    /// </exception>
    public Fraction Multiply(Fraction other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other), "Дробь не может быть null");

        int newNumerator = Numerator * other.Numerator;
        int newDenominator = Denominator * other.Denominator;

        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Умножает текущую дробь на целое число
    /// </summary>
    /// <param name="number">Целое число для умножения</param>
    /// <returns>Новая дробь - результат умножения</returns>
    public Fraction Multiply(int number) => Multiply(new Fraction(number));

    /// <summary>
    /// Делит текущую дробь на другую дробь
    /// </summary>
    /// <param name="other">Дробь-делитель</param>
    /// <returns>Новая дробь - результат деления</returns>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="other"/> равен null
    /// </exception>
    /// <exception cref="DivideByZeroException">
    /// Выбрасывается, если числитель дроби-делителя равен нулю
    /// </exception>
    public Fraction Divide(Fraction other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other), "Дробь не может быть null");

        if (other.Numerator == 0)
            throw new DivideByZeroException("Нельзя делить на дробь с нулевым числителем");

        int newNumerator = Numerator * other.Denominator;
        int newDenominator = Denominator * other.Numerator;

        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Делит текущую дробь на целое число
    /// </summary>
    /// <param name="number">Целое число-делитель</param>
    /// <returns>Новая дробь - результат деления</returns>
    /// <exception cref="DivideByZeroException">
    /// Выбрасывается, если <paramref name="number"/> равен нулю
    /// </exception>
    public Fraction Divide(int number)
    {
        if (number == 0)
            throw new DivideByZeroException("Нельзя делить на ноль");

        return Divide(new Fraction(number));
    }

    #endregion

    #region Перегрузки операторов

    /// <summary>
    /// Складывает две дроби
    /// </summary>
    public static Fraction operator +(Fraction a, Fraction b) => a.Add(b);

    /// <summary>
    /// Складывает дробь и целое число
    /// </summary>
    public static Fraction operator +(Fraction a, int b) => a.Add(b);

    /// <summary>
    /// Складывает целое число и дробь
    /// </summary>
    public static Fraction operator +(int a, Fraction b) => new Fraction(a).Add(b);

    /// <summary>
    /// Вычитает одну дробь из другой
    /// </summary>
    public static Fraction operator -(Fraction a, Fraction b) => a.Subtract(b);

    /// <summary>
    /// Вычитает целое число из дроби
    /// </summary>
    public static Fraction operator -(Fraction a, int b) => a.Subtract(b);

    /// <summary>
    /// Вычитает дробь из целого числа
    /// </summary>
    public static Fraction operator -(int a, Fraction b) => new Fraction(a).Subtract(b);

    /// <summary>
    /// Умножает две дроби
    /// </summary>
    public static Fraction operator *(Fraction a, Fraction b) => a.Multiply(b);

    /// <summary>
    /// Умножает дробь на целое число
    /// </summary>
    public static Fraction operator *(Fraction a, int b) => a.Multiply(b);

    /// <summary>
    /// Умножает целое число на дробь
    /// </summary>
    public static Fraction operator *(int a, Fraction b) => new Fraction(a).Multiply(b);

    /// <summary>
    /// Делит одну дробь на другую
    /// </summary>
    public static Fraction operator /(Fraction a, Fraction b) => a.Divide(b);

    /// <summary>
    /// Делит дробь на целое число
    /// </summary>
    public static Fraction operator /(Fraction a, int b) => a.Divide(b);

    /// <summary>
    /// Делит целое число на дробь
    /// </summary>
    public static Fraction operator /(int a, Fraction b) => new Fraction(a).Divide(b);

    /// <summary>
    /// Проверяет равенство двух дробей
    /// </summary>
    public static bool operator ==(Fraction a, Fraction b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    /// <summary>
    /// Проверяет неравенство двух дробей
    /// </summary>
    public static bool operator !=(Fraction a, Fraction b) => !(a == b);

    #endregion

    #region Переопределение методов Object

    /// <summary>
    /// Возвращает строковое представление дроби
    /// </summary>
    /// <returns>Строка в формате "числитель/знаменатель"</returns>
    public override string ToString() => $"{Numerator}/{Denominator}";

    /// <summary>
    /// Сравнивает текущую дробь с другим объектом
    /// </summary>
    /// <param name="obj">Объект для сравнения</param>
    /// <returns>true, если объект равен текущей дроби; иначе false</returns>
    public override bool Equals(object obj) => Equals(obj as Fraction);

    /// <summary>
    /// Возвращает хэш-код дроби
    /// </summary>
    /// <returns>Хэш-код, основанный на значениях числителя и знаменателя</returns>
    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    #endregion

    #region Реализация интерфейсов

    /// <summary>
    /// Сравнивает текущую дробь с другой дробью
    /// </summary>
    /// <param name="other">Другая дробь для сравнения</param>
    /// <returns>
    /// Меньше нуля, если текущая дробь меньше другой;
    /// Ноль, если дроби равны;
    /// Больше нуля, если текущая дробь больше другой
    /// </returns>
    public int CompareTo(Fraction other)
    {
        if (other is null) return 1;

        double thisValue = GetRealValue();
        double otherValue = other.GetRealValue();

        return thisValue.CompareTo(otherValue);
    }

    /// <summary>
    /// Проверяет равенство текущей дроби с другой дробью
    /// </summary>
    /// <param name="other">Другая дробь для сравнения</param>
    /// <returns>true, если дроби равны; иначе false</returns>
    public bool Equals(Fraction other)
    {
        if (other is null) return false;
        return Numerator == other.Numerator && Denominator == other.Denominator;
    }

    /// <summary>
    /// Создает новый объект, который является копией текущего экземпляра
    /// </summary>
    /// <returns>Новый объект Fraction с такими же значениями</returns>
    public object Clone() => new Fraction(Numerator, Denominator);

    #endregion
}

/// <summary>
/// Декоратор для дроби с кэшированием вещественного значения
/// </summary>
/// <remarks>
/// <para>Класс реализует паттерн Декоратор для оптимизации вычислений.</para>
/// <para>При первом вызове <see cref="GetRealValue"/> значение вычисляется и кэшируется.</para>
/// <para>При изменении числителя или знаменателя кэш сбрасывается.</para>
/// </remarks>
public class CachedFraction : IFractionOperations
{
    private readonly Fraction _fraction;
    private double? _cachedRealValue = null;
    private bool _isCacheValid = false;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="CachedFraction"/>
    /// </summary>
    /// <param name="fraction">Базовая дробь для кэширования</param>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="fraction"/> равен null
    /// </exception>
    public CachedFraction(Fraction fraction)
    {
        _fraction = fraction ?? throw new ArgumentNullException(nameof(fraction));
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="CachedFraction"/>
    /// </summary>
    /// <param name="numerator">Числитель дроби</param>
    /// <param name="denominator">Знаменатель дроби</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если знаменатель равен нулю
    /// </exception>
    public CachedFraction(int numerator, int denominator)
        : this(new Fraction(numerator, denominator)) { }

    /// <summary>
    /// Получает вещественное значение дроби с кэшированием
    /// </summary>
    /// <returns>Вещественное значение дроби</returns>
    /// <remarks>
    /// При первом вызове значение вычисляется и сохраняется в кэше.
    /// При последующих вызовах возвращается кэшированное значение.
    /// </remarks>
    public double GetRealValue()
    {
        if (!_isCacheValid)
        {
            _cachedRealValue = _fraction.GetRealValue();
            _isCacheValid = true;
        }
        return _cachedRealValue.Value;
    }

    /// <summary>
    /// Устанавливает новое значение числителя
    /// </summary>
    /// <param name="numerator">Новое значение числителя</param>
    /// <remarks>
    /// Сбрасывает кэш вещественного значения
    /// </remarks>
    public void SetNumerator(int numerator)
    {
        _fraction.SetNumerator(numerator);
        _isCacheValid = false;
    }

    /// <summary>
    /// Устанавливает новое значение знаменателя
    /// </summary>
    /// <param name="denominator">Новое значение знаменателя</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если знаменатель равен нулю
    /// </remarks>
    /// <remarks>
    /// Сбрасывает кэш вещественного значения
    /// </remarks>
    public void SetDenominator(int denominator)
    {
        _fraction.SetDenominator(denominator);
        _isCacheValid = false;
    }

    /// <summary>
    /// Возвращает строковое представление дроби
    /// </summary>
    public override string ToString() => _fraction.ToString();
}

// ================================ ГЛАВНАЯ ПРОГРАММА ================================

class Program
{
    static void Main()
    {
        Console.WriteLine("========== ДЕМОНСТРАЦИЯ РАБОТЫ С КОТАМИ ==========\n");
        DemonstrateCats();

        Console.WriteLine("\n\n========== ДЕМОНСТРАЦИЯ РАБОТЫ С ДРОБЯМИ ==========\n");
        DemonstrateFractions();
    }

    /// <summary>
    /// Демонстрирует работу с котами
    /// </summary>
    static void DemonstrateCats()
    {
        try
        {
            // 1. Создаем кота Барсик
            Cat barsik = new Cat("Барсик");
            Console.WriteLine($"Создан: {barsik}");

            // 2. Кот мяукает один раз
            Console.Write("Мяукает один раз: ");
            barsik.Meow();

            // 3. Кот мяукает три раза
            Console.Write("Мяукает три раза: ");
            barsik.Meow(3);

            // 4. Тестирование метода с несколькими котами
            Console.WriteLine("\n--- Тестирование метода MakeAllMeow ---");

            List<IMeowable> meowables = new List<IMeowable>
            {
                new Cat("Мурзик"),
                new Cat("Васька"),
                new RobotCat("RX-78"),
                new Cat("Рыжик")
            };

            Console.WriteLine("Все мяукают:");
            MeowService.MakeAllMeow(meowables);

            // 5. Подсчет мяуканий с использованием декоратора
            Console.WriteLine("\n--- Подсчет мяуканий ---");

            Cat murzik = new Cat("Мурзик");
            MeowCounter counter = new MeowCounter(murzik);

            Console.WriteLine($"До мяуканий: счетчик = {counter.MeowCount}");

            // Вызываем мяуканье несколько раз
            for (int i = 0; i < 3; i++)
            {
                counter.Meow();
            }

            Console.WriteLine($"После мяуканий: счетчик = {counter.MeowCount}");

            // 6. Тестирование с декоратором в методе MakeAllMeow
            Console.WriteLine("\n--- Подсчет мяуканий в методе MakeAllMeow ---");

            MeowCounter counter1 = new MeowCounter(new Cat("Барсик"));
            MeowCounter counter2 = new MeowCounter(new Cat("Мурзик"));
            MeowCounter counter3 = new MeowCounter(new RobotCat("AI-Cat"));

            List<IMeowable> countedMeowables = new List<IMeowable> { counter1, counter2, counter3 };

            Console.WriteLine("До вызова метода:");
            Console.WriteLine($"Барсик мяукал: {counter1.MeowCount} раз");
            Console.WriteLine($"Мурзик мяукал: {counter2.MeowCount} раз");

            Console.WriteLine("\nВызываем MakeAllMeow дважды:");
            MeowService.MakeAllMeow(countedMeowables);
            MeowService.MakeAllMeow(countedMeowables);

            Console.WriteLine("\nПосле вызова метода:");
            Console.WriteLine($"Барсик мяукал: {counter1.MeowCount} раз");
            Console.WriteLine($"Мурзик мяукал: {counter2.MeowCount} раз");
            Console.WriteLine($"Робокот мяукал: {counter3.MeowCount} раз");

            // 7. Проверка обработки исключений
            Console.WriteLine("\n--- Проверка обработки исключений ---");

            try
            {
                Cat invalidCat = new Cat("");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка создания кота: {ex.Message}");
            }

            try
            {
                Cat barsik2 = new Cat("Барсик");
                barsik2.Meow(0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка мяуканья: {ex.Message}");
            }

            try
            {
                MeowService.MakeAllMeow<IMeowable>(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ошибка вызова метода: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
        }
    }

    /// <summary>
    /// Демонстрирует работу с дробями
    /// </summary>
    static void DemonstrateFractions()
    {
        try
        {
            // 1. Создание экземпляров дробей
            Console.WriteLine("1. СОЗДАНИЕ ДРОБЕЙ:");
            Console.WriteLine(new string('-', 50));

            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(2, 3);
            Fraction f3 = new Fraction(3, 4);
            Fraction f4 = new Fraction(-2, 5);
            Fraction f5 = new Fraction(4); // целое число как дробь 4/1

            Console.WriteLine($"f1 = {f1}");
            Console.WriteLine($"f2 = {f2}");
            Console.WriteLine($"f3 = {f3}");
            Console.WriteLine($"f4 = {f4}");
            Console.WriteLine($"f5 = {f5}");

            // 2. Примеры использования каждого метода
            Console.WriteLine("\n2. ПРИМЕРЫ ОПЕРАЦИЙ:");
            Console.WriteLine(new string('-', 50));

            // Сложение дробей
            Fraction sum1 = f1.Add(f2);
            Console.WriteLine($"f1.Add(f2) = {FormatOperation(f1, "+", f2, sum1)}");

            // Вычитание дробей
            Fraction diff1 = f3.Subtract(f1);
            Console.WriteLine($"f3.Subtract(f1) = {FormatOperation(f3, "-", f1, diff1)}");

            // Умножение дробей
            Fraction prod1 = f1.Multiply(f2);
            Console.WriteLine($"f1.Multiply(f2) = {FormatOperation(f1, "*", f2, prod1)}");

            // Деление дробей
            Fraction quot1 = f2.Divide(f1);
            Console.WriteLine($"f2.Divide(f1) = {FormatOperation(f2, "/", f1, quot1)}");

            // Операции с целыми числами
            Console.WriteLine($"\nОперации с целыми числами:");
            Console.WriteLine($"f1.Add(2) = {FormatOperation(f1, "+", 2, f1.Add(2))}");
            Console.WriteLine($"f3.Subtract(1) = {FormatOperation(f3, "-", 1, f3.Subtract(1))}");
            Console.WriteLine($"f2.Multiply(3) = {FormatOperation(f2, "*", 3, f2.Multiply(3))}");
            Console.WriteLine($"f5.Divide(2) = {FormatOperation(f5, "/", 2, f5.Divide(2))}");

            // Использование перегруженных операторов
            Console.WriteLine("\n3. ИСПОЛЬЗОВАНИЕ ПЕРЕГРУЖЕННЫХ ОПЕРАТОРОВ:");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
            Console.WriteLine($"{f3} - {f1} = {f3 - f1}");
            Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
            Console.WriteLine($"{f2} / {f1} = {f2 / f1}");
            Console.WriteLine($"{f1} + 2 = {f1 + 2}");
            Console.WriteLine($"3 * {f2} = {3 * f2}");
            Console.WriteLine($"{f4} * {f3} = {f4 * f3} (работа с отрицательными)");

            // 4. Вычисление сложного выражения: f1.sum(f2).div(f3).minus(5)
            Console.WriteLine("\n4. СЛОЖНОЕ ВЫРАЖЕНИЕ:");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"Исходные дроби: f1={f1}, f2={f2}, f3={f3}");
            Console.WriteLine($"Вычисляем: f1.Add(f2).Divide(f3).Subtract(5)");

            // Вычисление по шагам
            Fraction step1 = f1.Add(f2);
            Console.WriteLine($"  Шаг 1: f1.Add(f2) = {step1}");

            Fraction step2 = step1.Divide(f3);
            Console.WriteLine($"  Шаг 2: {step1}.Divide(f3) = {step2}");

            Fraction result = step2.Subtract(5);
            Console.WriteLine($"  Шаг 3: {step2}.Subtract(5) = {result}");

            Console.WriteLine($"\nИтог одной строкой: {f1}.Add({f2}).Divide({f3}).Subtract(5) = {result}");
            Console.WriteLine($"Вещественное значение: {result.GetRealValue():F4}");

            // Сравнение дробей
            Console.WriteLine("\n5. СРАВНЕНИЕ ДРОБЕЙ:");
            Console.WriteLine(new string('-', 50));

            Fraction f6 = new Fraction(2, 4); // 1/2 после сокращения
            Fraction f7 = new Fraction(1, 2);
            Fraction f8 = new Fraction(3, 4);

            Console.WriteLine($"f6 = {f6} (исходно 2/4)");
            Console.WriteLine($"f7 = {f7}");
            Console.WriteLine($"f8 = {f8}");

            Console.WriteLine($"\nf6 == f7: {f6 == f7} (должно быть True)");
            Console.WriteLine($"f6.Equals(f7): {f6.Equals(f7)} (должно быть True)");
            Console.WriteLine($"f6 == f8: {f6 == f8} (должно быть False)");
            Console.WriteLine($"f6.CompareTo(f8): {f6.CompareTo(f8)} (должно быть -1)");
            Console.WriteLine($"f8.CompareTo(f6): {f8.CompareTo(f6)} (должно быть 1)");
            Console.WriteLine($"f6.CompareTo(f7): {f6.CompareTo(f7)} (должно быть 0)");

            // Клонирование
            Console.WriteLine("\n6. КЛОНИРОВАНИЕ:");
            Console.WriteLine(new string('-', 50));

            Fraction original = new Fraction(3, 5);
            Fraction clone = (Fraction)original.Clone();

            Console.WriteLine($"Оригинал: {original}");
            Console.WriteLine($"Клон: {clone}");
            Console.WriteLine($"Оригинал == Клон: {original == clone}");
            Console.WriteLine($"Ссылаются на один объект: {ReferenceEquals(original, clone)}");

            // Изменяем клон
            clone.SetNumerator(6);
            Console.WriteLine($"\nПосле изменения клона:");
            Console.WriteLine($"Оригинал: {original} (не изменился)");
            Console.WriteLine($"Клон: {clone} (изменился)");

            // Работа с интерфейсом IFractionOperations
            Console.WriteLine("\n7. РАБОТА С ИНТЕРФЕЙСОМ IFractionOperations:");
            Console.WriteLine(new string('-', 50));

            IFractionOperations ifraction = new Fraction(2, 3);
            Console.WriteLine($"Дробь через интерфейс: {ifraction}");
            Console.WriteLine($"Вещественное значение: {ifraction.GetRealValue():F4}");

            Console.WriteLine("\nИзменяем через интерфейс:");
            ifraction.SetNumerator(5);
            ifraction.SetDenominator(8);
            Console.WriteLine($"Новая дробь: {ifraction}");
            Console.WriteLine($"Новое значение: {ifraction.GetRealValue():F4}");

            // Кэшированная версия дроби
            Console.WriteLine("\n8. КЭШИРОВАННАЯ ВЕРСИЯ ДРОБИ:");
            Console.WriteLine(new string('-', 50));

            CachedFraction cached = new CachedFraction(1, 3);
            Console.WriteLine($"Дробь: {cached}");

            // Первое вычисление - вычисляется
            Console.WriteLine("Первое получение значения (должно вычислиться):");
            double val1 = cached.GetRealValue();
            Console.WriteLine($"  Значение: {val1:F6}");

            // Второе вычисление - берётся из кэша
            Console.WriteLine("Второе получение значения (должно взять из кэша):");
            double val2 = cached.GetRealValue();
            Console.WriteLine($"  Значение: {val2:F6}");
            Console.WriteLine($"  То же самое значение: {Math.Abs(val1 - val2) < 0.000001}");

            // Изменяем дробь - кэш сбрасывается
            Console.WriteLine("\nИзменяем дробь:");
            cached.SetNumerator(2);
            cached.SetDenominator(5);
            Console.WriteLine($"Новая дробь: {cached}");

            // Вычисляем снова - кэш пересчитывается
            Console.WriteLine("Получение значения после изменения (должно пересчитать):");
            double val3 = cached.GetRealValue();
            Console.WriteLine($"  Значение: {val3:F6}");

            // Проверка обработки исключений
            Console.WriteLine("\n9. ПРОВЕРКА ОБРАБОТКИ ИСКЛЮЧЕНИЙ:");
            Console.WriteLine(new string('-', 50));

            try
            {
                Fraction bad = new Fraction(1, 0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка создания дроби: {ex.Message}");
            }

            try
            {
                Fraction divByZero = f1.Divide(0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка деления: {ex.Message}");
            }

            try
            {
                Fraction f = new Fraction(3, -5);
                Console.WriteLine($"Дробь с отрицательным знаменателем автоматически корректируется: {f}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            // Демонстрация цепочки вызовов с операторами
            Console.WriteLine("\n10. ЦЕПОЧКА ВЫЗОВОВ С ОПЕРАТОРАМИ:");
            Console.WriteLine(new string('-', 50));

            // Альтернативный способ вычисления: f1.sum(f2).div(f3).minus(5)
            Fraction chainResult = f1.Add(f2).Divide(f3).Subtract(5);
            Console.WriteLine($"Цепочка вызовов: {f1}.Add({f2}).Divide({f3}).Subtract(5) = {chainResult}");

            // С использованием операторов
            Fraction operatorChainResult = (f1 + f2) / f3 - 5;
            Console.WriteLine($"С операторами: ({f1} + {f2}) / {f3} - 5 = {operatorChainResult}");
            Console.WriteLine($"Результаты совпадают: {chainResult == operatorChainResult}");

            // Проверка отрицательных дробей
            Console.WriteLine("\n11. ПРОВЕРКА ОТРИЦАТЕЛЬНЫХ ДРОБЕЙ:");
            Console.WriteLine(new string('-', 50));

            Fraction neg1 = new Fraction(-3, 4);
            Fraction neg2 = new Fraction(2, -5); // знаменатель станет положительным
            Console.WriteLine($"neg1 = {neg1}");
            Console.WriteLine($"neg2 = {neg2} (знаменатель автоматически стал положительным)");
            Console.WriteLine($"{neg1} + {neg2} = {neg1 + neg2}");
            Console.WriteLine($"{neg1} * {neg2} = {neg1 * neg2}");
            Console.WriteLine($"{neg1} - {neg2} = {neg1 - neg2}");
            Console.WriteLine($"{neg1} / {neg2} = {neg1 / neg2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nОшибка: {ex.Message}");
        }
    }

    /// <summary>
    /// Форматирует операцию с двумя дробями
    /// </summary>
    /// <param name="a">Первая дробь</param>
    /// <param name="op">Оператор</param>
    /// <param name="b">Вторая дробь</param>
    /// <param name="result">Результат</param>
    /// <returns>Отформатированная строка</returns>
    private static string FormatOperation(Fraction a, string op, Fraction b, Fraction result)
    {
        return $"{a} {op} {b} = {result}";
    }

    /// <summary>
    /// Форматирует операцию дроби с целым числом
    /// </summary>
    /// <param name="a">Дробь</param>
    /// <param name="op">Оператор</param>
    /// <param name="b">Целое число</param>
    /// <param name="result">Результат</param>
    /// <returns>Отформатированная строка</returns>
    private static string FormatOperation(Fraction a, string op, int b, Fraction result)
    {
        return $"{a} {op} {b} = {result}";
    }
}
