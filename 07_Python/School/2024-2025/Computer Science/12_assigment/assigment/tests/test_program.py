import pytest
from calc.program import calc_price

def test_calc_price_no_discount():
    assert calc_price(150, None) == 150

def test_calc_price_discount10():
    assert calc_price(200, "DISCOUNT10") == 180

def test_calc_price_discount20():
    assert calc_price(200, "DISCOUNT20") == 160

def test_calc_price_invalid_code():
    with pytest.raises(ValueError, match="Invalid discount code."):
        calc_price(200, "INVALID")

def test_calc_price_low_total():
    with pytest.raises(ValueError, match="The order must have a minimum of 100 to use a discount code."):
        calc_price(50, "DISCOUNT10")
