let maxRetries = 3;
let attempt = 0;
while (attempt < maxRetries) {
    if (tryConnect()) {
        console.log("Connected successfully.");
        break;
    } else {
        console.log("Retrying connection...");
        attempt++;
    }
}
if (attempt === maxRetries) {
    console.log("Failed to connect after 3 attempts.");
}
