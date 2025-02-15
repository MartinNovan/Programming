# Modify the code in the highlighted range, using the existing code, to achieve the result
class Counter:
    def __init__(self):
        self.count = 0

    def increment(self):
        self.count += 1

c1 = Counter()
c2 = c1
# Fix the error below

# Fix the error above
print("c2: " + str(c2.count)) # Expected result: c2: 1