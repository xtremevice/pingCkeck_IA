# User Interface Layout

## Main Window

```
┌────────────────────────────────────────────────────────────────────────────┐
│ Ping Monitor                                                          ╳ ☐ ▭ │
├────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│  Ping Monitor                                                               │
│                                                                             │
│  ┌──────────────────────────────────────────────────────────────────────┐  │
│  │ Enter URL or IP (e.g., google.com or 8.8.8.8)          │  Add Site   │  │
│  │                                                         │  Interval:  │  │
│  │                                                         │  [1000] ms  │  │
│  │                                                         │  Update     │  │
│  └──────────────────────────────────────────────────────────────────────┘  │
│                                                                             │
│  ┌──────────────────────────────────────────────────────────────────────┐  │
│  │ ┌────────────────────────────────────────────────────────────────┐  │  │
│  │ │ google.com                 Last    Avg(50)   Max    Graph       │  │  │
│  │ │ 42 ms (Online - Green)     42 ms   45.3 ms   78 ms  ▁▂▃▄▅▆▇█   │  │  │
│  │ │                                                       [Remove]    │  │  │
│  │ ├────────────────────────────────────────────────────────────────┤  │  │
│  │ │ 8.8.8.8                    Last    Avg(50)   Max    Graph       │  │  │
│  │ │ 23 ms (Online - Green)     23 ms   25.1 ms   32 ms  ▂▃▃▄▄▃▂▃   │  │  │
│  │ │                                                       [Remove]    │  │  │
│  │ ├────────────────────────────────────────────────────────────────┤  │  │
│  │ │ github.com                 Last    Avg(50)   Max    Graph       │  │  │
│  │ │ 156 ms (Online - Green)   156 ms  148.7 ms  201 ms  ▄▅▆▅▄▃▂▁   │  │  │
│  │ │                                                       [Remove]    │  │  │
│  │ ├────────────────────────────────────────────────────────────────┤  │  │
│  │ │ unreachable.test           Last    Avg(50)   Max    Graph       │  │  │
│  │ │ Offline (Red)               -      -         -       ─────────  │  │  │
│  │ │                                                       [Remove]    │  │  │
│  │ └────────────────────────────────────────────────────────────────┘  │  │
│  └──────────────────────────────────────────────────────────────────────┘  │
│                                                                             │
└────────────────────────────────────────────────────────────────────────────┘
```

## UI Elements Description

### Top Section (Controls)
1. **Title**: "Ping Monitor" - Large, bold text
2. **URL Input Box**: Text box for entering URLs or IP addresses
3. **Add Site Button**: Adds the entered URL/IP to the monitoring list
4. **Interval Label**: "Interval (ms):" label
5. **Interval Numeric Input**: Numeric up/down control (100-10000 range)
6. **Update Interval Button**: Applies new interval to all sites

### Middle Section (Site List)
- **Scrollable List**: Contains all monitored sites
- Each list item shows:
  - **URL/IP**: Site address (bold)
  - **Status**: Online (green) or Offline (red) with last ping time
  - **Last**: Most recent ping response time
  - **Avg (50)**: Average of last 50 pings
  - **Max**: Maximum ping time recorded
  - **Graph**: Mini line graph showing ping history (last 50 points)
  - **Remove Button**: Removes site from monitoring

### Visual Feedback
- **Green Text**: Site is online and responding
- **Red Text**: Site is offline or unreachable
- **Graph**: 
  - Blue line with light blue fill
  - Auto-scales to show relative ping times
  - Updates in real-time as new pings arrive
  - Shows last 50 data points

## Responsive Design
- Window is resizable
- List scrolls when many sites are added
- Minimum width: 1000px
- Minimum height: 600px
- Graph adapts to available width

## User Interactions
1. **Adding a site**: Type URL → Click "Add Site"
2. **Removing a site**: Click "Remove" button on the site row
3. **Changing interval**: Adjust number → Click "Update Interval"
4. **Monitoring**: Automatic - watch real-time updates

## Color Scheme
- **Background**: Light theme (white/light gray)
- **Text**: Dark gray/black
- **Online Status**: Green (#008000)
- **Offline Status**: Red (#FF0000)
- **Graph Line**: Light Blue (#ADD8E6)
- **Graph Fill**: Light Blue with transparency
- **Borders**: Light gray
- **Buttons**: Standard Avalonia Fluent theme

## Data Display Format
- Ping times: Displayed as whole numbers with "ms" suffix
- Average: Displayed with 1 decimal place and "ms" suffix
- Status messages: 
  - Online: "[ping time] ms" in green
  - Offline: "Offline" in red
