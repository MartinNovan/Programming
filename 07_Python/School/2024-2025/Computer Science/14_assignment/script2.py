import sys
from pathlib import Path

def process_file(file_path: Path) -> None:
    """Opens and processes a file line by line."""
    try:
        letter_list = {}
        with file_path.open('r', encoding='utf-8') as file:
            for line in file:
                line = line.strip()
                if not line:
                    continue
                for char in line:
                    if char.isalpha():
                        letter_list[char] = letter_list.get(char, 0) + 1
            for char, count in sorted(letter_list.items()):
                print(f"{char}: {count}")
    except FileNotFoundError:
        print(f"Error: File '{file_path}' not found.")
    except Exception as e:
        print(f"An unexpected error occurred: {e}")

def main() -> None:
    if len(sys.argv) != 2:
        print("Usage: python script1.py <path_to_file>")
        sys.exit(1)

    file_path = Path(sys.argv[1])
    process_file(file_path)

if __name__ == "__main__":
    main()
