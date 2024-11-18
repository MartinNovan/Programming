max_retries = 3
attempt = 0
while attempt < max_retries:
    if try_connect():
        print("Connected successfully.")
        break
    else:
        print("Retrying connection...")
        attempt += 1

if attempt == max_retries:
    print("Failed to connect after 3 attempts.")
