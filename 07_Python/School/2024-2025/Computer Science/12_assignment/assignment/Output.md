PS C:~\12_assignment\assignment> python -m pytest --cov=calc tests/
================================================================================= test session starts =================================================================================
platform win32 -- Python 3.13.2, pytest-8.3.4, pluggy-1.5.0
rootdir: C:~\12_assignment\assignment
plugins: cov-6.0.0
collected 5 items

tests\test_program.py .....                                                                                                                                                      [100%]

---------- coverage: platform win32, python 3.13.2-final-0 -----------
Name               Stmts   Miss  Cover
--------------------------------------
calc\__init__.py       0      0   100%
calc\program.py       11      0   100%
--------------------------------------
TOTAL                 11      0   100%


================================================================================== 5 passed in 0.20s ================================================================================== 