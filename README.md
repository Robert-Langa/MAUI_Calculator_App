
---

## ⚙️ How It Works

### 🔢 Number Input
- When a number button is clicked, `OnMultipleNumbersClicked()` is triggered.
- The input is appended to the current result.
- Handles resetting input when starting a new number.

### ➕ Operator Handling
- `OnMultipleOperatorsClicked()` determines if:
  - The user pressed `=` → calls `GetEquals()`
  - Any other operator → calls `GetOperators()`

### 🧠 Calculation Logic
- `GetOperators()`:
  - Stores the first number
  - Tracks the selected operator
  - Moves the calculator to the next state
- If multiple operations are chained:
  - It calculates intermediate results using `MathUtil.Calculate()`

---

## 🔄 State Management

The calculator uses a state system:

- **FirstNumber** → Waiting for first input
- **SecondNumber** → Waiting for second input

This ensures proper calculation flow and prevents invalid operations.

---

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022 or later
- .NET MAUI workload installed

### Run the App

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/CalculatorApp.git
