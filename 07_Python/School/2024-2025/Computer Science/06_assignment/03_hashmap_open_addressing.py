import time
import random

class OpenAddressingHashMap:
    def __init__(self, size):
        self.size = size
        self.table = [None] * size

    def hash_function(self, key):
        return hash(key) % self.size

    def add(self, key, value):
        index = self.hash_function(key)
        while self.table[index] is not None:
            existing_key, _ = self.table[index]
            if existing_key == key:
                self.table[index] = (key, value)
                return
            index = (index + 1) % self.size
        self.table[index] = (key, value)

    def find(self, key):
        index = self.hash_function(key)
        while self.table[index] is not None:
            existing_key, value = self.table[index]
            if existing_key == key:
                return value
            index = (index + 1) % self.size
        return None

def measure_time(operation, *args):
    start = time.time()
    result = operation(*args)
    end = time.time()
    return result, end - start

if __name__ == "__main__":
    hash_map = OpenAddressingHashMap(200000)
    data = list(range(1, 100001))
    random.shuffle(data)

    # Adding in batches
    for i in range(0, len(data), 10000):
        batch = data[i:i + 10000]
        _, duration = measure_time(lambda b: [hash_map.add(key, f"value{key}") for key in b], batch)
        print(f"Adding batch {i // 10000 + 1}: {duration:.6f} s")

    # Finding in batches
    random.shuffle(data)
    for i in range(0, len(data), 10000):
        batch = data[i:i + 10000]
        _, duration = measure_time(lambda b: [hash_map.find(key) for key in b], batch)
        print(f"Finding batch {i // 10000 + 1}: {duration:.6f} s")
