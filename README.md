# 💎 MAGNOLYA Jewelry Store - Cash Register System

## 📋 Project Overview

A comprehensive **B2B cash register system** built specifically for **MAGNOLYA Jewelry Store** using **C# and WinForms**, implementing a robust **3-layer architecture** (UI, Business Logic, Data Access Layer). This elegant system provides complete jewelry store management capabilities including inventory control, customer management, and promotional campaigns tailored for the luxury jewelry market.

### 🎯 Key Features

- **Luxury Jewelry Management**: Specialized interface for high-value jewelry inventory
- **Dual Interface System**: Separate interfaces for store managers and sales associates
- **Premium Customer Club**: VIP loyalty program with exclusive jewelry collections
- **Promotional Campaigns**: Special occasion discounts and seasonal offers
- **Real-time Stock Alerts**: Critical for expensive jewelry inventory management
- **Secure Order Management**: Enhanced security for valuable merchandise restocking

---

## 🏗️ Architecture

The project follows **SOLID principles** and **Design Patterns** with a clear **3-layer architecture**:

```
┌─────────────────┐
│   Presentation  │  ← WinForms UI Layer
│     Layer       │
├─────────────────┤
│   Business      │  ← Logic & Rules Layer
│   Logic Layer   │
├─────────────────┤
│   Data Access   │  ← Data Management Layer
│     Layer       │
└─────────────────┘
```

### 🔧 Technical Stack

- **Framework**: .NET Framework with C#
- **UI**: Windows Forms (WinForms)
- **Data Storage**: XML Files & In-Memory Collections
- **Architecture**: 3-Layer Architecture
- **Patterns**: Singleton, Simple Factory Method
- **Query Language**: LINQ

---

## 👥 User Roles & Permissions

### 🔑 Store Manager
- ✅ **Product Management**
  - View product catalog
  - Add new products
  - Update existing product details (name, price, inventory, etc.)
- ✅ **Inventory Management**
  - Receive low stock alerts
  - Process product orders (instant stock replenishment)
- ✅ **Promotion Management**
  - View active promotions
  - Create new promotional campaigns
  - Update or delete existing promotions

### 💍 Jewelry Sales Associate
- ✅ **Sales Operations**
  - Browse luxury jewelry catalog
  - Process customer transactions with authentication
  - Handle VIP customers and walk-in clients
- ✅ **Customer Management**
  - Register new VIP club members
  - Update existing customer preferences
  - Manage customer jewelry history and preferences

---

## 📊 Data Entities

### 💎 Jewelry Product
- **ID**: Unique jewelry identifier (6+ digits barcode)
- **Name**: Jewelry piece name
- **Category**: Jewelry type (Rings, Necklaces, Earrings, Bracelets, Watches)
- **Price**: Unit price (double) - supports high-value items
- **Stock**: Available quantity (int)
- **Material**: Gold, Silver, Platinum, Diamonds, etc.

### 👑 VIP Customer
- **ID**: National ID number
- **Name**: Customer full name
- **Address**: Customer address
- **Phone**: Contact number
- **Membership Level**: VIP status and preferences

### ✨ Jewelry Promotion
- **ID**: Unique promotion identifier
- **Product ID**: Target jewelry item
- **Required Quantity**: Minimum quantity for promotion
- **Promotional Price**: Discounted total price
- **VIP Exclusive**: VIP members only exclusive offers

---

## 🚀 Development Phases

### Phase 1: Data Access Layer (DAL)
- [x] Data contracts and entities design
- [x] Service interfaces for data access
- [x] In-memory data storage with collections
- [x] CRUD operations implementation
- [x] Exception handling
- [x] Console testing interface

### Phase 2: LINQ Integration
- [x] Generic service interface creation
- [x] Enhanced exception handling
- [x] IEnumerable collections integration
- [x] LINQ-only data processing (no loops)

### Phase 3: XML Data Persistence
- [x] XML file-based data storage implementation
- [x] Data serialization/deserialization

### Phase 4: Business Logic Layer
- [x] Complete layered model implementation
- [x] Singleton and Simple Factory patterns
- [x] Business logic entities and contracts
- [x] Generic business logic interface
- [x] Console testing for business functions

### Phase 5: Graphical User Interface
- [x] Manager interface (WinForms)
- [x] Cashier interface (WinForms)
- [x] Complete user experience implementation

## 📈 Sample Data

### Initial Data Setup
- **Jewelry Products**: Minimum 10 jewelry pieces across all categories
- **Promotions**: At least 5 seasonal/special occasion campaigns
- **VIP Customers**: Minimum 15 registered VIP club members
- **Categories**: 5 jewelry categories optimized for luxury store

### 💎 MAGNOLYA Jewelry Categories
- **💍 Rings**: Engagement, Wedding, Fashion rings
- **📿 Necklaces**: Chains, Pendants, Statement pieces  
- **👂 Earrings**: Studs, Hoops, Drop earrings
- **⌚ Bracelets**: Tennis, Charm, Cuff bracelets
- **⌚ Watches**: Luxury timepieces and accessories

---

## 🤝 Contributing

This is an academic project developed as part of a C# programming course. The project emphasizes:
- Clean code architecture
- SOLID principles implementation
- Design pattern usage
- Layered architecture best practices


*Built with ❤️ for MAGNOLYA Jewelry Store using C# and WinForms*

## ✨ About MAGNOLYA

MAGNOLYA Jewelry Store represents elegance, luxury, and timeless beauty. Our cash register system is designed to match the sophistication and attention to detail that defines our brand, ensuring every customer interaction reflects our commitment to excellence.
