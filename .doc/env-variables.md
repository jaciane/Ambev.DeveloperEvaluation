# Set environment variables
# Windows (PowerShell / CMD)
# Change the variables value
$env:ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=bd;Username=user;Password=pass"

# Linux/macOS (Bash)
# Change the variables value
export ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=bd;Username=user;Password=pass"

# Configure para Docker
# Change the variables value
environment:
  - ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=bd;Username=user;Password=pass"