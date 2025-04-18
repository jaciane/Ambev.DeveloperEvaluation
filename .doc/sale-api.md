[Back to README](../README.md)

### Sales

#### POST /Sales
- Description: Add a new Sale
- Request Body:
  ```json
  {
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "customerName": "string",
  "branchId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "branchName": "string",
  "items": [
    {
      "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "productName": "string",
      "unitPrice": 0,
      "quantity": 0,
      "discount": 0
    }
  ]
  }
  ```
- Response: 
  ```json
  {
  "data": {
    "id": "49d4a35a-c731-4c91-afd1-fa9f1ae27072",
    "saleNumber": "",
    "saleDate": "0001-01-01T00:00:00",
    "customerName": "string",
    "branchName": "string",
    "totalAmount": 0,
    "isCanceled": false,
    "items": [
      {
        "productName": "string",
        "quantity": 1,
        "unitPrice": 1000,
        "discount": 0,
        "totalPrice": 1000
      }
    ]
  },
  "success": true,
  "message": "Sale created successfully",
  "errors": []
  }
  ```

#### GET /Sales/{id}
- Description: Retrieve a specific Sale by ID
- Path Parameters:
  - `id`: Sale ID
- Response: 
  ```json
  {
  "data": {
    "id": "49d4a35a-c731-4c91-afd1-fa9f1ae27072",
    "saleNumber": "",
    "saleDate": "0001-01-01T00:00:00",
    "customerName": "string",
    "branchName": "string",
    "totalAmount": 0,
    "isCanceled": false,
    "items": [
      {
        "productName": "string",
        "quantity": 0,
        "unitPrice": 0,
        "discount": 0,
        "totalPrice": 0
      }
    ]
  },
  "success": true,
  "message": "Sale created successfully",
  "errors": []
  }
  ```

#### PUT /Sales
- Description: Update a specific Sale
- Path Parameters:
- Request Body:
  ```json
  {
  "id": "49d4a35a-c731-4c91-afd1-fa9f1ae27072",
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "customerName": "string",
  "branchId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "branchName": "string",
  "items": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "productName": "string",
      "unitPrice": 0,
      "quantity": 0,
      "discount": 0
    }
  ]
  }
  ```
- Response: 
  ```json
  {
  "data": {
    "id": "49d4a35a-c731-4c91-afd1-fa9f1ae27072",
    "saleNumber": "",
    "saleDate": "0001-01-01T00:00:00",
    "customerName": "string",
    "branchName": "string",
    "totalAmount": 0,
    "isCanceled": false,
    "items": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "productId": "",
        "productName": "string",
        "unitPrice": 0,
        "quantity": 0,
        "discount": 0
      }
    ]
  },
  "success": true,
  "message": "Sale updated successfully",
  "errors": []
  }
  ```

#### DELETE /Sales/{id}
- Description: Delete a specific Sale
- Path Parameters:
  - `id`: Sale ID
- Response: 
  ```json
  {
  "success": true,
  "message": "Sale deleted successfully",
  "errors": []
  }
  ```

<br/>
<div style="display: flex; justify-content: space-between;">
  <a href="./carts-api.md">Previous: Carts API</a>
  <a href="./auth-api.md">Next: Auth API</a>
</div>
