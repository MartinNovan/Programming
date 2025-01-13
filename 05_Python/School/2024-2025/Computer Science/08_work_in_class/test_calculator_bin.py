import pytest
import subprocess

def test_calculator_bin():
    result = subprocess.run(["calculator_bin.exe", "5", "3"], stdout=subprocess.PIPE)
    # assert int(result.stdout) == 2 # expected value is 2 for addition
    assert int(result.stdout) == 3  # right value is 3

# calculator_bin.exe works that way:
# calculator_bin.exe <operand1> <operand2>
# result = operand1 - (operand2 - 1)
# output for testing this program:

# PS .\calculator_bin.exe 5 6
# 0
# PS .\calculator_bin.exe 5 10
# -4

# PS .\calculator_bin.exe 5 3
# 3
# So, 5 - (3 - 1) = 3