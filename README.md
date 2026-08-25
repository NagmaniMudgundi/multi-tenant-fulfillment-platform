# Multi-Tenant Order & Fulfillment Platform

A SaaS-style platform where multiple companies (tenants) manage products,
warehouse stock, and order fulfillment — with live order tracking for customers.

## Why this project

Built to demonstrate full-stack .NET + React skills beyond CRUD: multi-tenancy,
optimistic concurrency, event-driven order processing (saga pattern), real-time
updates via SignalR, and a production-style deployment pipeline.

## Tech stack

**Backend:** ASP.NET Core (.NET 8), EF Core, SQL Server, JWT auth, RabbitMQ,
SignalR, Hangfire, Serilog, xUnit/Moq

**Frontend:** React, TypeScript, React Router, Axios, Bootstrap

**Infra:** Docker, GitHub Actions, Azure

## Architecture

<img width="1623" height="752" alt="Untitled" src="https://github.com/user-attachments/assets/cd3267ec-fc38-492e-be4a-078fefb3960e" />


### Order lifecycle

Placed → Reserved → Picked → Shipped → Delivered
Placed / Reserved → Cancelled (not allowed once Picked)

### Key decisions

- **Multi-tenancy:** shared database with a `TenantId` column + EF Core global
  query filters on every tenant-scoped entity, enforced at the data layer so no
  query can accidentally leak data across tenants.
- **Messaging:** order events published via RabbitMQ so stock reservation,
  billing, and notifications aren't coupled directly into the order-placement
  request — and a saga pattern cleanly reverses stock reservation if payment fails.
- **Concurrency:** stock rows carry a `RowVersion` for optimistic concurrency,
  preventing two orders from overselling the same unit.

## Status

🚧 In progress — building in public, day by day. See commit history for progress.

## Running locally

_(added once Docker Compose setup is done — Day 19)_

## Live demo

_(added once deployed — Day 21)_
