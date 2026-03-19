# Microservices E-Commerce System with RabbitMQ

A lightweight, multi-project ASP.NET Core Mini E-Commerce System demonstrating event-driven architecture using RabbitMQ.

This project showcases how to decouple a frontend web application from backend services using message queues. It strictly avoids direct HTTP/API calls from the frontend to the backend processors, replying entirely on asynchronous message passing, ensuring high availability and fault tolerance.

---

## 🏗️ Architecture & Projects

The solution (`ECommerceSystem.slnx`) contains 5 separate projects:

1. **`Shared.Models`** (Class Library): Contains the shared Data Transfer Objects (DTOs) like `Product`, `CartItem`, `CartMessage`, and `PaymentMessage`.
2. **`ECommerceMVC`** (Frontend App): The user-facing store catalog and shopping cart. It acts purely as a **RabbitMQ Producer**, publishing messages when users interact with the site (e.g., adding to cart, checking out).
3. **`ProductApi`** (Web API): A standalone service returning the product catalog. (Swagger accessible on port 5001).
4. **`CartApi`** (Web API Worker): Acts as a **RabbitMQ Consumer** listening to the `cart_queue`. It reads cart additions asynchronously and saves them in-memory. (Swagger accessible on port 5002).
5. **`PaymentApi`** (Web API Worker): Acts as a **RabbitMQ Consumer** listening to the `payment_queue`. It simulates payment processing with delays, logging receipts to the console, and saving transaction records. (Swagger accessible on port 5003).

---

## ⚙️ Prerequisites

To run this application, you will need:
- **.NET 10.0 SDK** (or newer) installed on your machine.
- **RabbitMQ Server** running locally on its default port `localhost:5672`.

### 👉 Quick Start for RabbitMQ (using Docker)
If you have Docker installed, you can spin up a RabbitMQ server with the management console instantly:
```bash
docker run -d --hostname rmq --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
*You can access the RabbitMQ Management dashboard at `http://localhost:15672` (Username: `guest`, Password: `guest`).*

---

## 🚀 Getting Started

To run the full suite, you must start all 4 web projects. Open your terminal in the root solution folder (`ECommerceSystem`) and launch each service in its own terminal window.

**Terminal 1:**
```bash
dotnet run --project ProductApi\ProductApi.csproj
```

**Terminal 2:**
```bash
dotnet run --project CartApi\CartApi.csproj
```

**Terminal 3:**
```bash
dotnet run --project PaymentApi\PaymentApi.csproj
```

**Terminal 4:**
```bash
dotnet run --project ECommerceMVC\ECommerceMVC.csproj
```

---

## 🛒 Testing the Flow

1. **Open the Storefront:** Navigate your web browser to **`http://localhost:5000`**.
2. **Browse Products:** You will see a list of available items.
3. **Add to Cart:** Click the "Add to Cart" button.
   - *Behind the scenes:* The MVC App publishes a `CartMessage` to RabbitMQ.
   - *Behind the scenes:* The `CartApi` instantly detects the message and stores the cart items. 
4. **Checkout:** Click "Cart" in the navigation bar, review your items, and click **"Proceed to Pay"**.
   - *Behind the scenes:* The MVC App clears your local cart and publishes a `PaymentMessage` to RabbitMQ.
5. **Verify Payment:**
   - You will be redirected to a green **Payment Successful** page.
   - Look at **Terminal 3 (PaymentApi)**: You will see a colorful receipt indicating your asynchronous payment was processed!

Enjoy exploring decoupled microservices!
