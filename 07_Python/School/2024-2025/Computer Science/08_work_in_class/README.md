# README.md

## Introduction to Code Testing

Code testing is a crucial step in the software development process that ensures applications function as expected and meet user requirements. In today's fast-paced world of software engineering, having a robust testing strategy is essential to identify bugs and deficiencies before they reach the production environment. Testing not only enhances code quality but also improves developers' confidence in their work and ensures that changes in the code do not affect existing functionalities.

### How Testing Affects Code Development

Testing has a significant impact on the entire code development process. It helps identify errors in the early stages, which can save time and costs associated with fixes. When tests are part of the development cycle, developers can iterate and implement new features more quickly without worrying that their changes will cause regressions. Testing also promotes better code design, as developers are compelled to write code that is testable and modular. This leads to cleaner and more maintainable code that is easier to extend and modify.

## Types of Testing

### 1. White Box Testing

White box testing, also known as structured testing, focuses on the internal structure and logic of the application. The tester has access to the source code and can perform tests based on knowledge of the implementation. This type of testing includes:

- **Unit Tests**: These test individual components or functions of the application. For example, in our `calculator.py` project, we created unit tests for functions like `add`, `subtract`, `multiply`, and `divide`.
  
- **Integration Tests**: These test the interaction between different modules or components of the application.

- **Code Coverage Testing**: This measures how much of the code is covered by tests, helping to identify untested parts of the application.

### 2. Black Box Testing

Black box testing focuses on the outputs of the application based on various inputs, without the tester knowing the internal structure of the code. This type of testing includes:

- **Functional Tests**: These verify whether the application meets specified functions and requirements.

- **User Tests**: These test the application from the end-user's perspective to ensure it is intuitive and easy to use.

- **Regression Tests**: These verify that new changes in the code do not affect existing functionalities.

## Testing Tools

There are many tools you can use for code testing. Some of the most popular include:

- **pytest**: A flexible and extensible testing framework for Python that supports both unit and integration tests.

- **unittest**: A built-in module in Python for writing and running tests.

- **coverage.py**: A tool for measuring code coverage that helps you determine how much of your code is being tested.

- **Selenium**: A tool for automating web applications, used for functional testing.

## How to Conduct Tests Properly

1. **Write Tests Before Code (TDD)**: Test-driven development (TDD) is a methodology where you first write tests and then implement the code that satisfies those tests. This ensures that the code is testable from the very beginning.

2. **Keep Tests Simple and Understandable**: Tests should be easy to read and clearly indicate what they are testing. This will facilitate maintenance and updates to the tests in the future.

3. **Run Tests Regularly**: Tests should be part of your development process. Run them regularly to ensure that new changes do not affect existing functionalities.

4. **Focus on Code Coverage**: Aim for high code coverage, but remember that the quality of tests is more important than quantity. You should test key functions and scenarios.

5. **Automate Tests**: Use CI/CD tools (e.g., Jenkins, GitHub Actions) to automate the running of tests on every commit or pull request.

## Setting Up the Testing Environment

To replicate the testing conducted here, you need to have Python installed on your machine along with the `pytest` library. Here’s how to set it up:

1. **Install Python**: Download and install Python from the official website [python.org](https://www.python.org/). Make sure to add Python to your system's PATH during installation.

2. **Install pytest**: Open your command line or terminal and run the following command to install pytest:
   ```bash
   pip install pytest
   ```

3. **Running Tests**: To run the tests, navigate to the directory containing your test files in the command line or terminal. You can execute the tests by running:
   ```bash
   pytest
   ```
   This command will automatically discover and run all the test files that follow the naming convention (files that start with `test_` or end with `_test.py`).

4. **Viewing Results**: After running the tests, pytest will display the results in the console, indicating which tests passed and which failed, along with any error messages.

## Detailed Analysis of Tests

### Tests in `calculator.py`

In the `calculator.py` file, we have the implementation of basic arithmetic operations. Tests for these functions are located in `test_calculator.py`. This file contains **white box testing** as we are testing the internal logic of the functions.

#### 1. Testing the `add` Function
```Python
def test_add():
    assert add(3, 2) == 5
    assert add(-1, 1) == 0
    assert add(-1, -1) == -2
    assert add(0, 0) == 0
    assert add(5.4, 2.1) == 7.5
    with pytest.raises(ValueError):
        add(5, "test")
```

- **Description**: We test various scenarios for the `add` function, including positive, negative, and zero values. We also test whether the function correctly raises an exception when one of the arguments is invalid (e.g., a string instead of a number).

#### 2. Testing the `subtract` Function

```python
def test_subtract():
    assert subtract(3, 2) == 1
    assert subtract(-1, 1) == -2
    assert subtract(-1, -1) == 0
    assert subtract(0, 0) == 0
    assert subtract(5.4, 2.1) == 3.3  # will fail bcs of floating point precision error
    with pytest.raises(ValueError):
        add(5, "test")
```

- **Description**: Similar to the `add` function, we test various scenarios for `subtract`. There is a note about a possible test failure due to floating-point precision error. This suggests that we could use `math.isclose` or `round` for comparing results.

#### 3. Testing the `multiply` Function

```python
def test_multiply():
    assert multiply(3, 2) == 6
    assert multiply(-1, 1) == -1
    assert multiply(-1, -1) == 1
    assert multiply(0, 0) == 0
    assert multiply(5.4, 2.1) == 11.34  # will fail bcs of floating point precision error
    with pytest.raises(ValueError):
        add(5, "test")
```

- **Description**: We test the `multiply` function with various inputs. Again, there is a floating-point precision issue noted.

#### 4. Testing the `divide` Function

```python
def test_divide():
    assert divide(3, 2) == 1.5
    assert divide(-1, 1) == -1
    assert divide(-1, -1) == 1
    assert divide(0, 1) == 0
    assert divide(5.4, 2.1) == 2.5714285714285716
    with pytest.raises(ValueError):
        divide(5, 0)
    with pytest.raises(ValueError):
        add(5, "test")
```

- **Description**: We test the `divide` function, including a test for division by zero, which should raise an exception. Again, there is a floating-point precision issue noted.

### Tests in `test_calculator_bin.py`

In the `test_calculator_bin.py` file, we test the external binary application `calculator_bin.exe`, which performs arithmetic operations. This test is an example of **black box testing** because we do not know the internal implementation of the binary file.

```python
def test_calculator_bin():
    result = subprocess.run(["calculator_bin.exe", "5", "3"], stdout=subprocess.PIPE)
    assert int(result.stdout) == 3  # right value is 3
```

- **Description**: We test whether the binary application returns the correct output for given inputs. In this case, we expect `calculator_bin.exe` to perform the operation `5 - (3 - 1)`, which should return 3. This test demonstrates how we can test external applications and verify their behavior.

### Tests in `test_advanced.py`

In the `test_advanced.py` file, we test functions from the `advanced.py` module, which contains advanced mathematical operations such as factorial, distance calculation, and BMI. This file also represents **white box testing** as we are testing the internal logic of the functions.

#### 1. Testing the `factorial` Function

```python
def test_factorial_positive():
    assert factorial(5) == 120, "Factorial of 5 should be 120"
    assert factorial(1) == 1,   "Factorial of 1 should be 1"

def test_factorial_zero():
    assert factorial(0) == 1, "Factorial of 0 should be 1"

def test_factorial_negative():
    with pytest.raises(ValueError):
        factorial(-3)
```

- **Description**: We test the `factorial` function for positive numbers, zero, and negative numbers. We expect an exception to be raised for negative numbers.

#### 2. Testing the `distance_2d` Function

```python
def test_distance_2d():
    d = distance_2d(0, 0, 3, 4)
    assert math.isclose(d, 5, rel_tol=1e-5), f"distance_2d(0,0,3,4) should be 5, got {d}"
```

- **Description**: We test the `distance_2d` function, which calculates the Euclidean distance between two points. We expect the distance between points (0,0) and (3,4) to be 5.

#### 3. Testing the `calculate_bmi` Function

```python
def test_bmi():
    res = calculate_bmi(70, 1.75)
    assert 22.8 < res < 22.9, f"BMI should be around 22.86, got: {res}"
```

- **Description**: We test the `calculate_bmi` function, which calculates BMI based on weight and height. We expect the result to be in the range of 22.8 to 22.9.

## Conclusion

Code testing is an essential part of software development that helps ensure the quality and reliability of applications. Whether you choose white box or black box testing, it is important to have well-defined tests and to run them regularly. By using the right tools and following best practices, you can significantly improve the quality of your code and user satisfaction. Testing is not just about finding bugs; it is also about ensuring that your code is robust, maintainable, and ready for future development.