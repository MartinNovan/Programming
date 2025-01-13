import pytest
import math
from advanced import factorial, distance_2d, calculate_bmi

# White box testing for advanced.py

def test_factorial_positive():
    assert factorial(5) == 120, "Factorial of 5 should be 120"
    assert factorial(1) == 1,   "Factorial of 1 should be 1"

def test_factorial_zero():
    assert factorial(0) == 1, "Factorial of 0 should be 1"

def test_factorial_negative():
    with pytest.raises(ValueError):
        factorial(-3)

def test_distance_2d():
    # The actual distance between (0,0) and (3,4) is 5 (3-4-5 triangle).
    d = distance_2d(0, 0, 3, 4)
    assert math.isclose(d, 5, rel_tol=1e-5), f"distance_2d(0,0,3,4) should be 5, got {d}"

def test_bmi():
    # BMI = kg / (m^2). For example, 70 kg, 1.75 m => 70 / (1.75^2) ~ 22.857
    res = calculate_bmi(70, 1.75)
    assert 22.8 < res < 22.9, f"BMI should be around 22.86, got: {res}"
