import sys
from pathlib import Path

def process_file(file_path: Path) -> None:
    """Opens and processes a file line by line."""
    try:
        inequality = 0
        with file_path.open('r', encoding='utf-8') as file:
            for line in file:
                if not line:
                    continue
                inequality += 2 ** (int(line) * -1)
            if inequality <= 1:
                print("Code can be made!")
                print("Here is an example of a code that can be made:")
                # generate prefix code

            else:
                print("Code cannot be made!")

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
