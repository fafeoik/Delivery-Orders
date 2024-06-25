import React from 'react';
import { Box, Typography, Grid, Button } from '@mui/joy';
import 'tailwindcss/tailwind.css';

export default function WholeOrder(){
  return (
    <Box
      sx={{
        width: '100%',
        height: 'auto',
        maxWidth: '500px',
        maxHeight: '900px',
        border: '1px solid #ccc',
        borderRadius: '8px',
        padding: '16px',
        boxShadow: '0px 2px 4px rgba(0, 0, 0, 0.1)',
      }}
      className="bg-white"
    >
      <Typography level="h5" sx={{ mb: 2 }}>
        Информация о заказе
      </Typography>
      <Button>Вернуться</Button>
      <Grid container spacing={2}>
        <Grid item xs={6}>
          <Typography>Номер заказа:</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Номер заказа</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Город отправителя:</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Город отправителя</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Адрес отправителя:</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Адрес отправителя</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Город получателя:</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Город получателя</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Адрес получателя:</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Адрес получателя</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Вес груза:</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Вес груза кг</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Дата забора груза:</Typography>
        </Grid>
        <Grid item xs={6}>
          <Typography>Дата забора груза</Typography>
        </Grid>
      </Grid>
    </Box>
  );
};