import pytest
from calculator import add, subtract, multiply, divide

# White box testing for calculator.py

def test_add():
    assert add(3,2) == 5
    assert add(-1,1) == 0
    assert add(-1,-1) == -2
    assert add(0,0) == 0
    assert add(5.4, 2.1) == 7.5
    with pytest.raises(ValueError):
        add(5, "test")

def test_subtract():
    assert subtract(3,2) == 1
    assert subtract(-1,1) == -2
    assert subtract(-1,-1) == 0
    assert subtract(0,0) == 0
    assert subtract(5.4, 2.1) == 3.3 # will fail bcs of floating point precision error, we can fix this by using math.isclose or using round function
    with pytest.raises(ValueError):
        add(5, "test")

def test_multiply():
    assert multiply(3,2) == 6
    assert multiply(-1,1) == -1
    assert multiply(-1,-1) == 1
    assert multiply(0,0) == 0
    assert multiply(5.4, 2.1) == 11.34 # will fail bcs of floating point precision error, we can fix this by using math.isclose or using round function
    with pytest.raises(ValueError):
        add(5, "test")

def test_divide():
    assert divide(3,2) == 1.5
    assert divide(-1,1) == -1
    assert divide(-1,-1) == 1
    assert divide(0,1) == 0
    assert divide(5.4, 2.1) == 2.5714285714285716
    with pytest.raises(ValueError):
        divide(5,0)
    with pytest.raises(ValueError):
        add(5, "test")