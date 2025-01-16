import subprocess

import pytest

# Run using the command "pytest ./test_text_stat.py"

def test_length_of_the_arg():
    # Tests for `-l` with expected values
    result = subprocess.run(["text_stats.exe", "-l", "hello"], stdout=subprocess.PIPE)
    assert int(result.stdout) == 5
    result2 = subprocess.run(["text_stats.exe", "-l", "hello,5"], stdout=subprocess.PIPE)
    assert int(result2.stdout) == 7
    result3 = subprocess.run(["text_stats.exe", "-l", "hello.5.5"], stdout=subprocess.PIPE)
    assert int(result3.stdout) == 9
    result4 = subprocess.run(["text_stats.exe", "-l", "hello 5"], stdout=subprocess.PIPE)
    # Here it depends if we want to count the space as a character or not
    assert int(result4.stdout) == 7
    # If we want to exclude the space
    # assert int(result5.stdout) == 6

def test_number_of_numbers():
    # Tests for `-d` with expected values
    result = subprocess.run(["text_stats.exe", "-d", "321"], stdout=subprocess.PIPE)
    assert int(result.stdout) == 3
    result2 = subprocess.run(["text_stats.exe", "-d", "hello"], stdout=subprocess.PIPE)
    assert int(result2.stdout) == 0
    result3 = subprocess.run(["text_stats.exe", "-d", "hello5"], stdout=subprocess.PIPE)
    assert int(result3.stdout) == 1
    result4 = subprocess.run(["text_stats.exe", "-d", "hello5.5"], stdout=subprocess.PIPE)
    assert int(result4.stdout) == 2

def test_number_of_words():
    # Tests for `-w` with expected values
    result = subprocess.run(["text_stats.exe", "-w", "hello"], stdout=subprocess.PIPE)
    assert int(result.stdout) == 1
    result2 = subprocess.run(["text_stats.exe", "-w", "hello5"], stdout=subprocess.PIPE)
    assert int(result2.stdout) == 1
    result3 = subprocess.run(["text_stats.exe", "-w", "hello.5.5"], stdout=subprocess.PIPE)
    assert int(result3.stdout) == 1
    result4 = subprocess.run(["text_stats.exe", "-w", "hello 5"], stdout=subprocess.PIPE)
    assert int(result4.stdout) == 2

def test_number_of_alphanumeric_chars():
    # Tests for `-a` with expected values
    result = subprocess.run(["text_stats.exe", "-a", "hello"], stdout=subprocess.PIPE)
    assert int(result.stdout) == 5
    result2 = subprocess.run(["text_stats.exe", "-a", "hello5"], stdout=subprocess.PIPE)
    assert int(result2.stdout) == 6
    result3 = subprocess.run(["text_stats.exe", "-a", "hello.5.5"], stdout=subprocess.PIPE)
    assert int(result3.stdout) == 7
    result4 = subprocess.run(["text_stats.exe", "-a", "hello 5"], stdout=subprocess.PIPE)
    assert int(result4.stdout) == 6

# I tried testing invalid arguments, but I'm not sure how to check it in tests (it works manually of course)
#def test_invalid_arg():
#    result = subprocess.run(["text_stats.exe", "-k", "hello"], stdout=subprocess.PIPE)
#    assert result.returncode == 2

def test_invalid_length_arg():
    # Tests with invalid characters for `-l` (or at least they should be invalid)
    result1 = subprocess.run(["text_stats.exe", "-l", ""], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result1.stdout)

    result2 = subprocess.run(["text_stats.exe", "-l", ",,"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result2.stdout)

    result3 = subprocess.run(["text_stats.exe", "-l", " "], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result3.stdout)

    result4 = subprocess.run(["text_stats.exe", "-l", ";"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result4.stdout)

    result5 = subprocess.run(["text_stats.exe", "-l", "💀"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result5.stdout)

    result6 = subprocess.run(["text_stats.exe", "-l", ",;"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result6.stdout)

def test_invalid_number_arg():
    # Tests with invalid characters for `-d`
    result1 = subprocess.run(["text_stats.exe", "-d", ""], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result1.stdout)

    result2 = subprocess.run(["text_stats.exe", "-d", ",;"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result2.stdout)

    result3 = subprocess.run(["text_stats.exe", "-d", " "], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result3.stdout)

    result4 = subprocess.run(["text_stats.exe", "-d", ";"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result4.stdout)

    result5 = subprocess.run(["text_stats.exe", "-d", "💀"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result5.stdout)

    result6 = subprocess.run(["text_stats.exe", "-d", "3,,"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result6.stdout)

def test_invalid_word_arg():
    # Tests with invalid characters for `-w`
    result1 = subprocess.run(["text_stats.exe", "-w", ""], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result1.stdout)

    result2 = subprocess.run(["text_stats.exe", "-w", ",,"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result2.stdout)

    result3 = subprocess.run(["text_stats.exe", "-w", " "], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result3.stdout)

    result4 = subprocess.run(["text_stats.exe", "-w", ";"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result4.stdout)

    result5 = subprocess.run(["text_stats.exe", "-w", "💀"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result5.stdout)

    result6 = subprocess.run(["text_stats.exe", "-w", ",;"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result6.stdout)

def test_invalid_alphanumeric_arg():
    # Tests with invalid characters for `-a`
    result1 = subprocess.run(["text_stats.exe", "-a", ""], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result1.stdout)

    result2 = subprocess.run(["text_stats.exe", "-a", ",,"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result2.stdout)

    result3 = subprocess.run(["text_stats.exe", "-a", " "], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result3.stdout)

    result4 = subprocess.run(["text_stats.exe", "-a", ";"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result4.stdout)

    result5 = subprocess.run(["text_stats.exe", "-a", "💀"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result5.stdout)

    result6 = subprocess.run(["text_stats.exe", "-a", ",;"], stdout=subprocess.PIPE)
    with pytest.raises(ValueError):
        int(result6.stdout)

# I can't think of anything else 💀