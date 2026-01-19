# C# Delegates - Learning Projects 📚

This repository contains **4 step-by-step projects** to help you learn **Delegates in C#** from basics to advanced concepts.

> 💡 **What is a Delegate?**  
> A delegate is like a **pointer to a method**. It allows you to pass methods as arguments, store them in variables, and call them later.

---

## 📖 Projects Overview

| # | Project | What You'll Learn |
|---|---------|------------------|
| 1 | [DelegateBasicExample](https://github.com/KartikZCoding/csharp-delegate-callback-varience-func-action-predecate/tree/472c79bade90ed00d464d5467d0cff8d83c59359/DelegateBasicExample) | Basic delegate syntax, single & multicast delegates |
| 2 | [CovarianceAndContaVarianceDelegateExample](https://github.com/KartikZCoding/csharp-delegate-callback-varience-func-action-predecate/tree/472c79bade90ed00d464d5467d0cff8d83c59359/CovarianceAndContavarianceDelegateExample) | Covariance & Contravariance in delegates |
| 3 | [CallbackSampleCode](https://github.com/KartikZCoding/csharp-delegate-callback-varience-func-action-predecate/tree/472c79bade90ed00d464d5467d0cff8d83c59359/CallbackSampleCode) | Callbacks - passing & returning delegates |
| 4 | [FuncActionPredecateExamples](https://github.com/KartikZCoding/csharp-delegate-callback-varience-func-action-predecate/tree/472c79bade90ed00d464d5467d0cff8d83c59359/FuncActionPredecateExamples) | Built-in delegates: Func, Action, Predicate |

---

## 1. DelegateBasicExample

### 🎯 Goal
Learn the **basics of delegates** - how to create, assign, and use them.

### 📝 What This Project Covers

#### Step 1: Create a Delegate
First, we define a delegate that can point to any method that takes a `string` and returns `void`:

```csharp
delegate void LogDel(string text);
```

#### Step 2: Assign Methods to Delegate
You can assign both **static methods** and **instance methods** to a delegate:

```csharp
// Instance method
Log log = new Log();
LogDel logDel = new LogDel(log.LogTextToFile);

// Static method
LogDel logDel1 = new LogDel(LogTextToScreen);
```

#### Step 3: Multicast Delegate (Call Multiple Methods)
You can combine multiple methods using the `+` operator:

```csharp
LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;
multiLogDel("Hello"); // Calls BOTH methods!
```

#### Step 4: Pass Delegate as Argument
Delegates can be passed to other methods:

```csharp
static void LogText(LogDel logDel, string text)
{
    logDel(text);  // Call the delegate
}
```

### ▶️ How to Run
```bash
cd DelegateBasicExample
dotnet run
```

---

## 2. CovarianceAndContaVarianceDelegateExample

### 🎯 Goal
Understand **Covariance** and **Contravariance** in delegates.

### 📝 What This Project Covers

#### What is Covariance? (Return types)
**Covariance** allows a delegate to point to a method that returns a **more derived (child)** type.

```csharp
// Delegate expects Animal return type
delegate Animal AnimalReturner(string name, int age);

// But we can assign a method that returns Dog (child of Animal)!
AnimalReturner animalReturner = AnimalFactory.ReturnDog;
Animal dog = animalReturner("Buddy", 3);
```

**Simple Rule:** Return type can be **more specific** (child class) ✅

#### What is Contravariance? (Parameter types)
**Contravariance** allows a delegate to point to a method that accepts a **less derived (parent)** type.

```csharp
// Delegate expects Dog as parameter
delegate void LogDogDetails(Dog dog);

// But we can assign a method that accepts Animal (parent of Dog)!
LogDogDetails logDogDetails = LogAnimalInfo;
```

**Simple Rule:** Parameter type can be **less specific** (parent class) ✅

### 🔍 Easy Memory Trick
| Concept | Direction | Rule |
|---------|-----------|------|
| **Covariance** | OUT (return) | Child → Parent ✅ |
| **Contravariance** | IN (parameter) | Parent → Child ✅ |

### ▶️ How to Run
```bash
cd CovarianceAndContavarianceDelegateExample
dotnet run
```

---

## 3. CallbackSampleCode

### 🎯 Goal
Learn how to use delegates for **callbacks** - a common pattern in real applications.

### 📝 What This Project Covers

#### What is a Callback?
A **callback** is when you pass a method (delegate) to another method, and it gets "called back" later.

#### Scenario 1: Pass Delegate as Parameter
```csharp
public delegate void PrintHelpDel(int amount);

// Method that accepts a delegate
public void PrintNumber(int amount, PrintHelpDel printHelpDel)
{
    printHelpDel(amount);  // "callback" the passed method
}

// Usage - pass different methods!
p.PrintNumber(100, p.Print);  // Output: Price: 100
p.PrintNumber(200, p.Cost);   // Output: Cost: 200
```

#### Scenario 2: Return Delegate from Method
```csharp
public delegate void MessageDel(string message);

public MessageDel Demo()
{
    return Message;  // Return a method reference
}

// Usage
p.Demo()("Hello from Demo");  // Output: Message: Hello from Demo
```

### 💡 Real-World Use Cases
- Event handlers (button clicks, etc.)
- Async operations (notify when done)
- Plugin systems (inject custom behavior)

### ▶️ How to Run
```bash
cd CallbackSampleCode
dotnet run
```

---

## 4. FuncActionPredecateExamples

### 🎯 Goal
Learn the **built-in delegate types** in C#: `Func`, `Action`, and `Predicate`.

### 📝 What This Project Covers

#### Why Use Built-in Delegates?
Instead of creating your own delegates every time, C# provides ready-made ones!

---

### 🔵 Func<T, TResult>
**Use when:** Your method **returns a value**

```csharp
// Func<input1, input2, returnType>
Func<int, int, int> calc = (a, b) => a + b;
Console.WriteLine(calc(1, 2));  // Output: 3

// With more parameters
Func<float, float, int, float> calc2 = (a, b, c) => (a + b) * c;
```

**Rule:** Last type is always the **return type**

---

### 🟢 Action<T>
**Use when:** Your method **returns nothing (void)**

```csharp
// Action with multiple parameters
Action<int, string, string, decimal, char, bool> employeeDetails = 
    (id, fname, lname, salary, gender, isManager) => 
        Console.WriteLine($"Id: {id}\nName: {fname} {lname}");

employeeDetails(1, "John", "Doe", 50000, 'M', false);
```

**Rule:** No return type - just performs an action

---

### 🟡 Predicate<T>
**Use when:** Your method **returns true/false**

```csharp
// Filter employees where Gender is 'M'
Predicate<Employee> isMale = e => e.Gender == 'M';

// Use with filtering
List<Employee> maleEmployees = employees.FilterEmployee(e => e.Gender == 'M');
```

**Rule:** Always returns `bool` - used for conditions

---

### 📊 Quick Comparison

| Delegate | Returns | Example |
|----------|---------|---------|
| `Func<T, TResult>` | A value | `Func<int, int, int>` → takes 2 ints, returns int |
| `Action<T>` | Nothing (void) | `Action<string>` → takes string, returns nothing |
| `Predicate<T>` | true/false (bool) | `Predicate<Employee>` → takes Employee, returns bool |

### ▶️ How to Run
```bash
cd FuncActionPredecateExamples
dotnet run
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed
- Any code editor (VS Code, Visual Studio, etc.)

### Clone & Run
```bash
# Clone the repository
git clone https://github.com/KartikZCoding/csharp-delegate-callback-varience-func-action-predecate.git

# Navigate to any project
cd DelegateBasicExample

# Run the project
dotnet run
```

---

## 📚 Learning Path

```
1. DelegateBasicExample
   └── Start here! Learn delegate basics
   
2. CovarianceAndContaVarianceDelegateExample
   └── Understand type flexibility in delegates
   
3. CallbackSampleCode
   └── Learn the callback pattern
   
4. FuncActionPredecateExamples
   └── Master built-in delegates
```

---

## 🤝 Contributing
Feel free to fork this repo and add more examples!

## 📄 License
This project is for **learning purposes**. Use it freely!

---

**Happy Learning! 🎉**
