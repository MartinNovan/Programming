import pytest
from text_stats import length, count_words, count_digits, count_alnum, divide
# length
def test_length_short():
    assert length('car') == 3
    assert length('Lorem ipsum') == 11
    input_text = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.'
    assert length(input_text) == 56
def test_length_no_text():
    assert length('') == 0
def test_length_long():
    long_text = 'Helloooo'
    text_1 = long_text * 100
    text_2 = long_text * 1000
    text_3 = long_text * 1000000
    assert length(text_1) == len(text_1)
    assert length(text_2) == len(text_2)
    assert length(text_3) == len(text_3) # this test failed first time but after removing % 1000 from text_stats.py it passed

def test_divide():
    assert divide(10, 5) == 2
    assert divide(8, 8) == 1
def test_divide_by_noint():
    assert divide(5, 2) == 2.5
    assert divide(10, 3) == 10/3
def test_divide_negative():
    assert divide(-10, 5) == -2
    assert divide(10, -5) == -2
def test_divide_zero():
    with pytest.raises(ZeroDivisionError):
        divide(10, 0)