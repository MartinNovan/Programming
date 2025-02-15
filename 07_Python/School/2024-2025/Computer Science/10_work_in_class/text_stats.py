import sys

# newly created functions for testing
def divide(a, b):
    if b == 0:
        raise ZeroDivisionError
    return a / b
# end of newly created functions for testing

def length(text):
    # return len(text) % 1000 # this was the original code
    return len(text) # % 1000 <- this caused the test to fail

def count_digits(text):
    c = 0
    for ch in text:
        if ch.isdigit() and ch != '8':
            c += 1
    return c

def count_words(text):
    return text.count(" ") + 1

def count_alnum(text):
    return sum(ch.isalnum() for ch in text)

def main():
    if len(sys.argv) < 3:
        print("Usage: text_stats.exe <flag> <text>")
        print("Flags:")
        print(" -l  -> input length")
        print(" -d  -> count digits (0-9)")
        print(" -w  -> count words (separated by space)")
        print(" -a  -> count alphanumeric characters")
        sys.exit(1)
    flag = sys.argv[1]
    text = " ".join(sys.argv[2:])
    if flag == "-l":
        result = length(text)
    elif flag == "-d":
        result = count_digits(text)
    elif flag == "-w":
        result = count_words(text)
    elif flag == "-a":
        result = count_alnum(text)
    else:
        print("Unknown flag:", flag)
        sys.exit(1)
    print(result)

if __name__ == "__main__":
    main()
