import random

# Simulating the Squid Game bridge challenge

def simulate_game():
    total_panels = 20  # Total number of panels in the game
    successful_panels = 0  # Count of successfully crossed panels
    
    for _ in range(total_panels):  # Repeat until all panels are crossed or the player falls
        if random.random() < 0.5:  # 50% chance of the panel being safe
            successful_panels += 1
        else:
            break  # The player falls on a broken panel
    
    return successful_panels  # Return the number of successfully crossed panels

def main():
    num_trials = 100000  # Number of trials to run
    total_successful_panels = 0

    for _ in range(num_trials):  # Repeat until all trials are completed
        total_successful_panels += simulate_game()  # Add the number of successfully crossed panels

    average_successful_panels = total_successful_panels / num_trials  # Calculate the average
    print(f'Average number of panels crossed by the player: {average_successful_panels}')  # Output the result

if __name__ == "__main__":
    main()