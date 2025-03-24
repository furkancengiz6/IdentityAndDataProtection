# User Authentication API

Bu proje, kullanıcı kayıt ve giriş işlemleri için JWT tabanlı kimlik doğrulama sağlayan bir Web API sunmaktadır. Projede `ASP.NET Core`, `Entity Framework`, ve `JWT` kullanılarak bir kullanıcı doğrulama ve token oluşturma sistemi geliştirilmiştir.

## Teknolojiler

- **ASP.NET Core**: Web API geliştirme çerçevesi.
- **Entity Framework Core**: Veritabanı işlemleri için ORM.
- **SQL Server**: Veritabanı sunucusu.
- **JWT**: JSON Web Token ile kimlik doğrulama.
- **Swagger**: API dokümantasyonu.

## Başlangıç

### Gereksinimler

- .NET 6.0 veya üzeri
- SQL Server
- Visual Studio veya başka bir IDE

### Kurulum

1. Projeyi klonlayın:

    ```bash
    git clone <repo-url>
    cd UserAuthApi
    ```

2. NuGet paketlerini yükleyin:

    ```bash
    dotnet restore
    ```

3. Veritabanı bağlantısını ve JWT ayarlarını `appsettings.json` dosyasında yapılandırın.

    ```json
    "Jwt": {
      "Key": "superSecretKey12345!",
      "Issuer": "UserAuthApi",
      "Audience": "UserAuthApiUsers"
    }
    ```

4. Veritabanı migrasyonlarını oluşturun ve veritabanını güncelleyin:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. API'yi başlatın:

    ```bash
    dotnet run
    ```

### API Kullanımı

#### 1. Kayıt Ol (Register)

- **Endpoint**: `POST /api/auth/register`
- **Body**:

    ```json
    {
        "fullName": "John Doe",
        "email": "john.doe@example.com",
        "password": "SecurePassword123"
    }
    ```

- **Başarılı Yanıt**:

    ```json
    "Kayıt başarılı!"
    ```

#### 2. Giriş Yap (Login)

- **Endpoint**: `POST /api/auth/login`
- **Body**:

    ```json
    {
        "email": "john.doe@example.com",
        "password": "SecurePassword123"
    }
    ```

- **Başarılı Yanıt**:

    ```json
    {
        "token": "your_jwt_token_here"
    }
    ```

