import pytest
from script_1 import add_numbers, subtract_numbers

def test_add_numbers_int():
    assert add_numbers(5, 3) == 8
    assert add_numbers(5, -3) == 2

def test_add_numbers_int_negative():
    assert add_numbers(-5, 3) == -2
    assert add_numbers(-5, -3) == -8

def test_add_numbers_zero():
    assert add_numbers(5, 0) == 5
    assert add_numbers(-5, 0) == -5

def test_add_numbers_large():
    assert add_numbers(1000000, 1000000) == 2000000
    assert add_numbers(-1000000, -1000000) == -2000000

def test_add_numbers_float(): # there is a bug in the script
    assert add_numbers(5.5, 3.5) == 9
    assert add_numbers(5.5, -3.5) == 2

def test_subtract_numbers_int():
    assert subtract_numbers(5, 3) == 2
    assert subtract_numbers(5, 5) == 0

def test_subtract_numbers_int_negative():
    assert subtract_numbers(-5, 3) == -8
    assert subtract_numbers(-5, -3) == -2

def test_subtract_numbers_zero():
    assert subtract_numbers(5, 0) == 5
    assert subtract_numbers(-5, 0) == -5

def test_subtract_numbers_large():
    assert subtract_numbers(1000000, 1000000) == 0
    assert subtract_numbers(-1000000, -1000000) == 0

def test_subtract_numbers_float(): # there is a bug in the script
    assert subtract_numbers(5.5, 3.5) == 2
    assert subtract_numbers(5.5, -3.5) == 9