# Old code
# max_retries = 3
# attempt = 0
# while attempt < max_retries:
#     if try_connect():
#         print("Connected successfully.")
#         break
#     else:
#         print("Retrying connection...")
#         attempt += 1
# if attempt == max_retries:
#     print("Failed to connect after 3 attempts.")

# New code with named constant
MAX_RETRIES = 3
attempt = 0

while attempt < MAX_RETRIES:
    if try_connect():
        print("Connected successfully.")
        break
    else:
        print("Retrying connection...")
        attempt += 1

if attempt == MAX_RETRIES:
    print(f"Failed to connect after {MAX_RETRIES} attempts.")